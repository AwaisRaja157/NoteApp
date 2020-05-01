namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Note1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Notes.Note", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Notes.Note", "ImagePath");
        }
    }
}
