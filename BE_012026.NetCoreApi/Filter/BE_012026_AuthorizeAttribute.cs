using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;

namespace BE_012026.NetCoreApi.Filter
{
    //Attribute de danh dau cac action can su dung filter nay
    public class BE_012026_AuthorizeAttribute : TypeFilterAttribute
    {
        public BE_012026_AuthorizeAttribute(string _functionCode, string _permission) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { _functionCode, _permission };
        }
    }
    public class AuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        private string _functionCode { get; set; }
        private string _permission { get; set; }
        public AuthorizeActionFilter(string functionCode, string permission)
        {
            _functionCode = functionCode;
            _permission = permission;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated)
            {
                //Neu khong co xac thuc, tra ve unauthorized
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { message = "Vui long dang nhap de thuc hien chuc nang nay" });
                return;
            }

            var userClaims = identity.Claims;
            var UserID = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value);
            var IsAdmin = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.IsPersistent)?.Value);

            //check permission
            //goi db
            // b1: Tu _functionCode => FunctionID
            // b2: UserID +FunctionID => quyen
            if (IsAdmin != 1)
            {
                //khac admin thi check quyen
                switch (_permission)
                {
                    case "ISVIEW":  //check quyen view
                        break;
                    case "ISINSERT": //check quyen insert
                        break;
                    case "ISUPDATE": //check quyen update
                        break;
                    case "ISDELETE": //check quyen delete
                        break;
                }
            }
        }
    }
}
