using System.Data.Entity;
using arkitektum.kommit.noark.tjeneste.Models.Arkivstruktur;

namespace arkitektum.kommit.noark.tjeneste.Models.arkitektum.kommit.noark
{
    public class tjenesteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<arkitektum.kommit.noark.tjeneste.Models.arkitektum.kommit.noark.tjenesteContext>());

        public tjenesteContext() : base("name=tjenesteContext")
        {
        }

        public DbSet<Arkivskaper> Arkivskapers { get; set; }

        public DbSet<Arkiv> Arkivs { get; set; }

        public DbSet<Arkivdel> Arkivdels { get; set; }

        public DbSet<Mappe> Mappes { get; set; }
    }
}
