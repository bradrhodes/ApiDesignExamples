using FluentMigrator;

namespace ApiDesignExamples.CRUD.Migrations
{
    [Migration(20211015151700)]
    public class Migration_20211015151700 : Migration
    {
        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("CustomerId").AsGuid()
                .WithColumn("Status").AsString();

            Create.Table("Customer")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString()
                .WithColumn("LastName").AsString();

            Create.Table("ShippingInfo")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("StreetAddress").AsString()
                .WithColumn("PostalCode").AsString()
                .WithColumn("Province").AsString();

            Create.Table("Product")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString();

            Create.Table("Cart")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey();

            Create.Table("OrderItems")
                .WithColumn("OrderId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("ProductId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Quantity").AsInt16();

            Create.Table("CartItems")
                .WithColumn("CartId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("ProductId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Quantity").AsGuid();
        }

        public override void Down()
        {
            Delete.Table("Order");
            Delete.Table("Customer");
            Delete.Table("ShippingInfo");
            Delete.Table("Product");
            Delete.Table("Cart");
            Delete.Table("OrderItems");
            Delete.Table("CartItems");
        }
    }
}
