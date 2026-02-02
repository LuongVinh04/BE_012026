using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataObject
{
    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
    }
    public class  AccountLoginResponse : ReturnData
    {
        public int AccountID { set; get; } 
        public string? UserName { set; get; }
        public string ? FullName { set; get; }
        public string? token { set; get; }
        public string? refreshToken { set; get; }
    }
}
