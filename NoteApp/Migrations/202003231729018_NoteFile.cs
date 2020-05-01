namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Notes.NoteFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NoteID = c.Int(nullable: false),
                        Filepath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Notes.Note",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "ToDOS.ToDo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Accounts.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Accounts.User");
            DropTable("ToDOS.ToDo");
            DropTable("Notes.Note");
            DropTable("Notes.NoteFile");
        }
    }
}
