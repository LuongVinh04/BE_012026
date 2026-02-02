using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataObject
{
    public class AccountUpdateRefreshRequestData
    {
        public int AccountID { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
