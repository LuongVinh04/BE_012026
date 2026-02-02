using BE_012026.DataAccess.NetCore.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.IServices
{
    public interface IAccountRepository
    {
        Task<Account> Account_Login(AccountLoginRequestData requestData);

        Task<int> Acccount_Update_RefreshToken(AccountUpdateRefreshRequestData requestData);
        Task<Account> Account_GetByUserName(string UserName);

    }
}
