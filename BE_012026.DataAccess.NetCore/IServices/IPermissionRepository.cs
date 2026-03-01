using BE_012026.DataAccess.NetCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BE_012026.DataAccess.NetCore.IServices
{
    public interface IPermissionRepository
    {
        Task<bool> HasPerMission(int accountId, string functionCode, PermissionType action);
    }
}
