using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataObject
{
    public class AccountLoginRequestData
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }   
    }
}
