using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataObject.User_Session
{
    public class User_Session
    {
        public int AccountID { get; set; }
        public string? Token { get; set; }
        public string? DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public DateTime? ExpiredTime { get; set; }
    }
}
