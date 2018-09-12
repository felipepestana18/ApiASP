
using PluginApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Plugin.Controllers
{
    public class CadastrosContext : DbContext
    {
        public CadastrosContext() : base("MvcCadastros.Properties.Settings.cadastrosConnString")
        {
            Database.SetInitializer<CadastrosContext>(
                new DropCreateDatabaseIfModelChanges<CadastrosContext>()
                );
        }

        public DbSet<Usuarios> Usuarios { get; set; }       

    }
}