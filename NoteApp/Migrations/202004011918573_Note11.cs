namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Note11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("Notes.Note", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("Notes.Note", "ImagePath", c => c.String());
        }
    }
}
