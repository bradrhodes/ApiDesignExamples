using FluentMigrator;

namespace ApiDesignExamples.CRUD.Migrations
{
    [Migration(20211015151500)]
    public class Migration_20211015151500 : Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}