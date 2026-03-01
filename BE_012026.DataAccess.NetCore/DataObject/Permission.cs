using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataObject
{
    public class Permission
    {
        public int PermissionID {set ; get;}
        public int? AccountID {set ; get;}
        public int? FunctionID {set ; get;}
        public int? IsView { set ; get;}
        public int? IsInsert { set ; get;}
        public int? IsDelete { set ; get;}
        public int? IsExport { set ; get;}
    }
}
