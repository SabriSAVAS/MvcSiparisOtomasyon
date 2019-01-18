using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Entities.Concrete
{
    public class OrderBasket : EntityBase
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DisCount { get; set; }
        public decimal DisCountTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Tax1Total { get; set; }
        public decimal Tax2Total { get; set; }
        public decimal Tax3Total { get; set; }
        public decimal Tax4Total { get; set; }
        public decimal Total { get; set; }
    }
}
