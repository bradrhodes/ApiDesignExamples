using ApiDesignExamples.NonCRUD.Migrations.SampleData;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDesignExamples.CRUD
{
    public static class AppExtensions
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
            return app;
        }

        public static IApplicationBuilder PrePopulate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            // var customerData = scope.ServiceProvider.GetService<CustomerData>();
            // customerData.PopulateData().GetAwaiter().GetResult();

            var productData = scope.ServiceProvider.GetService<ProductData>();
            productData.PopulateData().GetAwaiter().GetResult();

            return app;
        }
    }
}