using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SiparisEnt.Dto.AccountVM
{
    public class AccountSearchModel
    {
        public string UserName { get; set; }
        public string eMail { get; set; }
        public IPagedList<AccountModel> AccountList { get; set; }
        public int? Page { get; set; }
    }
}
