using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Enum
{
    public enum AccountManager_Status
    {
        ACCOUNT_Name_NOT_VALID = -1,
        ACCOUNT_INSERT_SUCCESS = 1,
        ACCOUNT_UPDATE_SUCCESS = 2,
        ACCOUNT_DELETE_SUCCESS = 3,
        ACCOUNT_GETLIST_SUCCESS = 4,
        ACCOUNT_GETLIST_FAILURE = 5,
        ACCOUNT_GETLIST_EMPTY = 6,
        ACCOUNT_GETLIST_ERROR = 7,
        ACCOUNT_GETLIST_EXCEPTION = 8,
        ACCOUNT_GETLIST_TIMEOUT = 9,
        ACCOUNT_GETLIST_NOT_FOUND = 10
    }
}
