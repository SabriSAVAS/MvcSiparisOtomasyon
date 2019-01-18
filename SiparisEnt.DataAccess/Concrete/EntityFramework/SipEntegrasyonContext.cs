using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SiparisEnt.DataAccess.Concrete.EntityFramework.Mappings;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
    public class SipEntegrasyonContext : DbContext
    {
        public SipEntegrasyonContext() : base("DbServer")
        {
            //  Database.SetInitializer<SipEntegrasyonContext>(new DropCreateDatabaseIfModelChanges<SipEntegrasyonContext>());
            // Database.SetInitializer<SipEntegrasyonContext>(new CreateDatabaseIfNotExists<SipEntegrasyonContext>());
            //Database.SetInitializer<SipEntegrasyonContext>(new DropCreateDatabaseIfModelChanges<SipEntegrasyonContext>());
            Database.SetInitializer<SipEntegrasyonContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAuthorized> CustomerAuthorized { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Exc> Excs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBasket> OrderBaskets { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Status> Status { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new CustomerAuthorizedMap());
        }
    }
}