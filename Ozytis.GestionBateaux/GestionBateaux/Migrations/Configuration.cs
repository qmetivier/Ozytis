namespace GestionBateaux.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<GestionBateaux.Models.BddContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GestionBateaux.Models.BddContext context)
        {
            ///Définie une liste de Roles
            var roles = new List<Role>
            {
                new Role{Nom = "Commandant"},
                new Role{Nom = "Second"},
                new Role{Nom = "Cuistot"},
                new Role{Nom = "Canonnier"},
                new Role{Nom = "Medecin"}
            };
            ///Pour chaque Role le rajoute dans le context de la Bdd
            roles.ForEach(x => context.Roles.AddOrUpdate(p => p.Nom, x));
            ///Synchronise les changements dans la Bdd
            context.SaveChanges();

            ///Définie une liste de Bateaux
            var types = new List<GestionBateaux.Models.Type>
            {
                new GestionBateaux.Models.Type{Nom = "Fregat de 33 canons"},
                new GestionBateaux.Models.Type{Nom = "Cuirasses pre-Dreadnought"}

            };
            ///Pour chaque Bateau le rajoute dans le context de la Bdd
            types.ForEach(t => context.Types.AddOrUpdate(p => p.Nom, t));
            ///Synchronise les changements dans la Bdd
            context.SaveChanges();

            ///Définie une liste de Type_Roles
            var type_roles = new List<Type_Role>
            {
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Fregat de 33 canons").Id,
                    RoleId = roles.Single(r => r.Nom == "Commandant").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 1
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Fregat de 33 canons").Id,
                    RoleId = roles.Single(r => r.Nom == "Second").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 1
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Fregat de 33 canons").Id,
                    RoleId = roles.Single(r => r.Nom == "Cuistot").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 1,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Fregat de 33 canons").Id,
                    RoleId = roles.Single(r => r.Nom == "Canonnier").Id,
                    Nb_Role_min = 33,
                    Nb_Role_max = 50,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Fregat de 33 canons").Id,
                    RoleId = roles.Single(r => r.Nom == "Medecin").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 1,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Cuirasses pre-Dreadnought").Id,
                    RoleId = roles.Single(r => r.Nom == "Commandant").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 1,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Cuirasses pre-Dreadnought").Id,
                    RoleId = roles.Single(r => r.Nom == "Second").Id,
                    Nb_Role_min = 1,
                    Nb_Role_max = 2,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Cuirasses pre-Dreadnought").Id,
                    RoleId = roles.Single(r => r.Nom == "Cuistot").Id,
                    Nb_Role_min = 4,
                    Nb_Role_max = 6,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Cuirasses pre-Dreadnought").Id,
                    RoleId = roles.Single(r => r.Nom == "Canonnier").Id,
                    Nb_Role_min = 20,
                    Nb_Role_max = 25,
                },
                new Type_Role
                {
                    TypeId = types.Single(t => t.Nom == "Cuirasses pre-Dreadnought").Id,
                    RoleId = roles.Single(r => r.Nom == "Medecin").Id,
                    Nb_Role_min = 3,
                    Nb_Role_max = 5,
                }
            };
            ///Pour chaque Type_Role dans la Liste créé
            foreach (Type_Role tp in type_roles)
            {
                ///Si les Types et Roles sont existant et qu'il n'y a pas d'ambiguité
                var type_RoleInDatabase = context.Type_Roles.Where(
                        t =>
                            t.Type.Id == tp.TypeId &&
                            t.Role.Id == tp.RoleId).SingleOrDefault();
                if (type_RoleInDatabase == null)
                {
                    ///Ajoute le Type_Role dans le context de la Bdd
                    context.Type_Roles.Add(tp);
                }
                ///Synchronise les changements dans la Bdd
                context.SaveChanges();
            }
        }
    }
}
