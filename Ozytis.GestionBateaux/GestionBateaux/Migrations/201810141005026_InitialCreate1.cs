namespace GestionBateaux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personnes", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Personnes", "Role_Bateau_Id", "dbo.Roles");
            DropForeignKey("dbo.Roles", "Personne_Id", "dbo.Personnes");
            DropIndex("dbo.Personnes", new[] { "Role_Id" });
            DropIndex("dbo.Personnes", new[] { "Role_Bateau_Id" });
            DropIndex("dbo.Roles", new[] { "Personne_Id" });
            CreateTable(
                "dbo.RolePersonnes",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Personne_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Personne_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.Personne_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Personne_Id);
            
            AddColumn("dbo.Personnes", "Id_Role_Bateau", c => c.Int(nullable: false));
            DropColumn("dbo.Personnes", "Role_Id");
            DropColumn("dbo.Personnes", "Role_Bateau_Id");
            DropColumn("dbo.Roles", "Personne_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Personne_Id", c => c.Int());
            AddColumn("dbo.Personnes", "Role_Bateau_Id", c => c.Int());
            AddColumn("dbo.Personnes", "Role_Id", c => c.Int());
            DropForeignKey("dbo.RolePersonnes", "Personne_Id", "dbo.Personnes");
            DropForeignKey("dbo.RolePersonnes", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RolePersonnes", new[] { "Personne_Id" });
            DropIndex("dbo.RolePersonnes", new[] { "Role_Id" });
            DropColumn("dbo.Personnes", "Id_Role_Bateau");
            DropTable("dbo.RolePersonnes");
            CreateIndex("dbo.Roles", "Personne_Id");
            CreateIndex("dbo.Personnes", "Role_Bateau_Id");
            CreateIndex("dbo.Personnes", "Role_Id");
            AddForeignKey("dbo.Roles", "Personne_Id", "dbo.Personnes", "Id");
            AddForeignKey("dbo.Personnes", "Role_Bateau_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.Personnes", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
