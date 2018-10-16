namespace GestionBateaux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bateaux",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Type_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Bateau_Id = c.Int(),
                        Role_Id = c.Int(),
                        Role_Bateau_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bateaux", t => t.Bateau_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Bateau_Id)
                .Index(t => t.Bateau_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Role_Bateau_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Personne_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Personne_Id)
                .Index(t => t.Personne_Id);
            
            CreateTable(
                "dbo.Type_Role",
                c => new
                    {
                        TypeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Nb_Role_min = c.Int(nullable: false),
                        Nb_Role_max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Type_Role", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Type_Role", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Roles", "Personne_Id", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "Role_Bateau_Id", "dbo.Roles");
            DropForeignKey("dbo.Personnes", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Personnes", "Bateau_Id", "dbo.Bateaux");
            DropForeignKey("dbo.Bateaux", "Type_Id", "dbo.Types");
            DropIndex("dbo.Type_Role", new[] { "RoleId" });
            DropIndex("dbo.Type_Role", new[] { "TypeId" });
            DropIndex("dbo.Roles", new[] { "Personne_Id" });
            DropIndex("dbo.Personnes", new[] { "Role_Bateau_Id" });
            DropIndex("dbo.Personnes", new[] { "Role_Id" });
            DropIndex("dbo.Personnes", new[] { "Bateau_Id" });
            DropIndex("dbo.Bateaux", new[] { "Type_Id" });
            DropTable("dbo.Type_Role");
            DropTable("dbo.Roles");
            DropTable("dbo.Personnes");
            DropTable("dbo.Types");
            DropTable("dbo.Bateaux");
        }
    }
}
