using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SiparisEnt.Dto.AccountVM;
using SiparisEnt.Dto.CatalogVM;
using SiparisEnt.Dto.CustomerVM;
using SiparisEnt.Dto.OrderVM;
using SiparisEnt.Dto.ProductVM;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Mappings.AutoMapper.Profiles
{
   public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CustomerDetail, CustomerDetailModel>().ReverseMap();
            CreateMap<User, AccountModel>().ReverseMap();
            CreateMap<OrderDetailItem, OrderDetailItemModel>().ReverseMap();
            CreateMap<OrderDetailBasket, OrderDetailBasketModel>().ReverseMap();

            CreateMap<Customer, CustomerListPopup>().ReverseMap();
            CreateMap<Product, ProductListPopup>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailBasket>().ReverseMap();

            CreateMap<OrderBasket, OrderDetail>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailBasketModel>().ReverseMap();
        }
    }
}
