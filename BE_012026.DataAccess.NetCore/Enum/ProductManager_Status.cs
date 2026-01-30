using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Enum
{
    public enum ProductManager_Status
    {
        PRODUCT_NAME_NOT_VALID = -1,
        PRODUCT_INSERT_SUCCESS = 1,
        PRODUCT_NOT_FOUND = 0,
        PRODUCT_UPDATE_SUCCESS = 2,
        PRODUCT_DELETE_SUCCESS = 3
        
    }
}
