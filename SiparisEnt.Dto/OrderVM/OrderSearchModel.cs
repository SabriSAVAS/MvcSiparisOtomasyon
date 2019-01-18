using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;

namespace SiparisEnt.Dto.OrderVM
{
  public  class OrderSearchModel
    {
        public OrderSearchModel()
        {
            StartDateTime ="01.01."+DateTime.Now.Year;
            EndDateTime = "31.12." + DateTime.Now.Year;
            StatusList=new List<SelectListItem>();
            Status2List = new List<SelectListItem>();
            StatusId = 0;
            Status2Id = 1;
        }
        public string OrderNo { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int? StatusId { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public IPagedList<OrderDetailItemModel> OrderDetailItemModels { get; set; }
        public int? Page { get; set; }


        //
        public int? Status2Id { get; set; }
        public List<SelectListItem> Status2List { get; set; }


    }
}
