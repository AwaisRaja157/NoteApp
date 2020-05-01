namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteFile1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Notes.NoteFile", "Imagepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Notes.NoteFile", "Imagepath");
        }
    }
}
