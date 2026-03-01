using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.Enum;
using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace BE_012026.DataAccess.NetCore.Services
//{
//    ////public class PermissionRepository : IPermissionRepository
    //{
    //    private readonly BE_012026Dbcontext _context;
    //    public PermissionRepository(BE_012026Dbcontext context)
    //    {
    //        _context = context;
    //    }  
        //public async Task<bool> HasPerMission(int accountId, string permissionName, PermissionType action)
        //{
        //    //var permission = await _context.permission
        //    //.Include(p => p.Function)
        //    //.FirstOrDefaultAsync(p =>
        //    //    p.AccountID == accountId &&
        //    //    p.Function.FunctionCode == functionCode);
        //    //var permission = _context.permission?.FirstOrDefault(x => x.)

        //    //if (permission == null) return false;

        //    //return action switch
        //    //{
        //    //    PermissionType.View => permission.IsView == 1,
        //    //    PermissionType.Insert => permission.IsInsert == 1,
        //    //    PermissionType.Delete => permission.IsDelete == 1,
        //    //    PermissionType.Export => permission.IsExport == 1,
        //    //    _ => false
        //    //};
//        //}
//    }
//}
