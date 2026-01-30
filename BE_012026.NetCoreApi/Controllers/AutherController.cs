using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.Enum;
using BE_012026.DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_012026.NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAccountRepository _accountRepositpry;
        private readonly IConfiguration _configuration;
        public AuthenController(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepositpry = accountRepository;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(AccountLoginRequestData requestData)
        {
            var returnData = new AccountLoginResponse();
            try
            {
                //b1: Check login 
                if (string.IsNullOrEmpty(requestData.UserName) || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_Name_NOT_VALID;
                    returnData.ResponseMessage = "Ten hoac mat khau dang nhap khong hop le";
                    return Ok(returnData);
                }
                var account = await _accountRepositpry.Account_Login(requestData);

                if (account == null)
                {
                    returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_Name_NOT_VALID;
                    returnData.ResponseMessage = "Ten hoac mat khau dang nhap khong hop le";
                    return Ok(returnData);
                }

                //b2: tao ra claim, token
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.PrimarySid, account.AccountID.ToString()),
                };
                var tokenNew = CreateToken(authClaims);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenNew);


                //b3: tra ve token
                returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_INSERT_SUCCESS;
                returnData.token = token;
                returnData.UserName = account.UserName;
                returnData.FullName = account.FullName;
                returnData.AccountID = account.AccountID;

                return Ok(returnData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
