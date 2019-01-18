using System.Data.Entity.Migrations;
using SiparisEnt.DataAccess.Concrete.EntityFramework;

namespace SiparisEnt.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SipEntegrasyonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SipEntegrasyonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}