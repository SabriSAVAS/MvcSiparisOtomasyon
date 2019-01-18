using SiparisEnt.WebUI.Infrastructure.Attribute;
using System.Web.Mvc;


namespace SiparisEnt.WebUI.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public BaseController()
        {
            //this.GetRegionInfo();
        }
        //void GetRegionInfo()
        //{
        //    CultureInfo newCulture = new CultureInfo("tr-TR");
        //    newCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        //    newCulture.NumberFormat.CurrencyGroupSeparator = "";
        //    newCulture.NumberFormat.NumberDecimalSeparator = ".";
        //    newCulture.NumberFormat.NumberGroupSeparator = "";
        //    newCulture.NumberFormat.PercentDecimalSeparator = ".";
        //    newCulture.NumberFormat.PercentGroupSeparator = "";
        //    Thread.CurrentThread.CurrentCulture = newCulture;//this one work fine
        //}

    }
}