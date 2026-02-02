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


        public async Task<int> Acccount_Update_RefreshToken(AccountUpdateRefreshRequestData requestData)
        {
            try
            {
                var account = _context.account?.FirstOrDefault(x => x.AccountID == requestData.AccountID);
                if (account == null)
                {
                    throw new Exception("Khong tim thay tai khoan");
                }
                account.AccountID = requestData.AccountID;
                account.RefreshToken = requestData.RefreshToken;
                account.ExpiredTime = requestData.ExpiredTime;
                 _context.account.Update(account);

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public async Task<Account> Account_GetByUserName(string UserName) 
        {
            return _context.account.Where(s => s.UserName == UserName).FirstOrDefault();
        }


    }
}

