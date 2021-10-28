using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ApiDesignExamples.CRUD.Cart;
using ApiDesignExamples.CRUD.Customer;
using ApiDesignExamples.CRUD.Dapper;
using ApiDesignExamples.CRUD.Migrations;
using ApiDesignExamples.CRUD.Migrations.SampleData;
using ApiDesignExamples.CRUD.Order;
using ApiDesignExamples.CRUD.Product;
using ApiDesignExamples.CRUD.ShippingInfo;
using Dapper;
using FluentMigrator.Runner;

namespace ApiDesignExamples.CRUD
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
            const string dbName = "Data Source=CrudDb.db";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiDesignExamples.CRUD", Version = "v1" });
            });
            services
                .AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddSQLite()
                    .WithGlobalConnectionString(dbName)
                    .ScanIn(typeof(Migrations.Migration_20211015151500).Assembly).For.Migrations());

            services.AddSingleton(new DatabaseConfig {Name = dbName});

            services.AddSingleton<IGenericCustomerRepository, CustomerRepository>();
            services.AddSingleton<IGenericProductRepository, ProductRepository>();
            services.AddSingleton<IGenericCartRepository, CartRepository>();
            services.AddSingleton<IGenericShippingInfoRepository, ShippingInfoRepository>();
            services.AddSingleton<IGenericOrderRepository, OrderRepository>();

            services.AddSingleton<CustomerData>();
            services.AddSingleton<ProductData>();

            // Dapper configuration
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDesignExamples.CRUD v1"));
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
