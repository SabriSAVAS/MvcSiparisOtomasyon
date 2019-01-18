using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework.Mappings
{
  public  class CustomerAuthorizedMap:EntityTypeConfiguration<CustomerAuthorized>
    {
        public CustomerAuthorizedMap()
        {
            ToTable(@"CustomerAuthorized", "dbo");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
        }
    }
}
