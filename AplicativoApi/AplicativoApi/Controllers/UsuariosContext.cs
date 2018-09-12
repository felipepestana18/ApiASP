
using PluginApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plugin.Controllers
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UsuariosContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        public DbSet<Usuarios> Usuario { get; set; }

    }
}
