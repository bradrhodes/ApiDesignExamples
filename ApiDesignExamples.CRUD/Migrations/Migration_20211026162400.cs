using FluentMigrator;

namespace ApiDesignExamples.CRUD.Migrations
{
    [Migration(20211026162400)]
    public class Migration_20211026162400 : Migration
    {
        public override void Up()
        {
            Delete.Table("Cart");
        }

        public override void Down()
        {
            Create.Table("Cart")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey();
        }
    }
}