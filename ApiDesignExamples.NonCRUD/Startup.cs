using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD;
using ApiDesignExamples.NonCRUD.Dapper;
using ApiDesignExamples.NonCRUD.Migrations;
using ApiDesignExamples.NonCRUD.Migrations.SampleData;
using Dapper;
using FluentMigrator.Runner;
using MediatR;

namespace ApiDesignExamples.NonCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            const string dbName = "Data Source=NonCrudDb.db";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiDesignExamples.NonCRUD", Version = "v1" });
            });
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddSQLite()
                    .WithGlobalConnectionString(dbName)
                    .ScanIn(typeof(Migrations.Migration_20211015151500).Assembly).For.Migrations());

            services.AddSingleton(new DatabaseConfig {Name = dbName});
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddSingleton<ProductData>();

            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));
            SqlMapper.AddTypeHandler(new GuidTypeMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDesignExamples.NonCRUD v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Migrate();
            app.PrePopulate();
        }
    }
}
