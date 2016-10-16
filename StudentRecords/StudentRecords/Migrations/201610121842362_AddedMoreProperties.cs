namespace StudentRecords.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Description", c => c.String());
            AddColumn("dbo.Subjects", "Semestar", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Difficulty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Difficulty");
            DropColumn("dbo.Subjects", "Semestar");
            DropColumn("dbo.Subjects", "Description");
        }
    }
}
