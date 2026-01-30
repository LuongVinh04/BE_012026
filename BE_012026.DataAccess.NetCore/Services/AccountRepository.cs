using BE_012026.CommonNetcore;
using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BE_012026Dbcontext _context;
        public AccountRepository(BE_012026Dbcontext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<Account> Account_Login(AccountLoginRequestData requestData)
        {
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    throw new Exception("Du lieu dau vao khong hop le");
                }
                var passwordHash = Sercutity.ComputeSha256Hash(requestData.Password);
                return _context.account?.FirstOrDefault(x => x.UserName == requestData.UserName && x.Password == passwordHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

