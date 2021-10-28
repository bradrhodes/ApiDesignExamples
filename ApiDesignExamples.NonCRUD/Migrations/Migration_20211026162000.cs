using FluentMigrator;

namespace ApiDesignExamples.NonCRUD.Migrations
{
    [Migration(20211026162000)]
    public class Migration_20211026162000 : Migration
    {
        public override void Up()
        {
            Create.Column("ShippingInfoId").OnTable("Order").AsGuid();
        }

        public override void Down()
        {
            Delete.Column("ShippingInfoId").FromTable("Order");
        }
    }
}
