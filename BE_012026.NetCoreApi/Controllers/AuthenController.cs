
using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.Enum;
using BE_012026.DataAccess.NetCore.IServices;
using BE_012026.DataObject.User_Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE_012026.NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAccountRepository _accountRepositpry;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        public AuthenController(IAccountRepository accountRepository, IConfiguration configuration, IDistributedCache cache)
        {
            _accountRepositpry = accountRepository;
            _configuration = configuration;
            _cache = cache;
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
                    new Claim(ClaimTypes.IsPersistent, account.IsAdmin.ToString())
                };
                var tokenNew = CreateToken(authClaims);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenNew);

                //tao refresh token
                var refreshToken = GenerateRefreshToken();


                //lay expired refresh token tu config
                var expiredRefreshToken = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]));
                //luu vao db

                var updateRefreshToken = await _accountRepositpry.Acccount_Update_RefreshToken(new AccountUpdateRefreshRequestData
                {
                    AccountID = account.AccountID,
                    RefreshToken = refreshToken,
                    ExpiredTime = expiredRefreshToken
                });

                //  Luu token vao Redis. Voi thoi gian song = thoi han cua token
                var userSession = new User_Session
                {
                    AccountID = account.AccountID,
                    Token = token,
                    DeviceID = requestData.DeviceID,
                    ExpiredTime = tokenNew.ValidTo,
                };
                var keyCache = $"User_Session_"+account.AccountID+ "_" + requestData.DeviceID;
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) //thoi gian het han cache
                };

                await _cache.SetStringAsync(keyCache, JsonConvert.SerializeObject(userSession), cacheOptions);



                //b3: tra ve token
                returnData.ResponseCode = (int)AccountManager_Status.ACCOUNT_INSERT_SUCCESS;
                returnData.token = token;
                returnData.UserName = account.UserName;
                returnData.FullName = account.FullName;
                returnData.AccountID = account.AccountID;
                returnData.refreshToken = refreshToken;
                returnData.ResponseMessage = "Dang nhap thanh cong";

                return Ok(returnData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            //giai ma token
            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {//khong giai ma duoc
                return BadRequest("Invalid access token or refresh token");
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string username = principal.Identity.Name;

            // lay name tu identity trong ham giai ma token
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var user = await _accountRepositpry.Account_GetByUserName(username);

            if (user == null || user.RefreshToken != refreshToken || user.ExpiredTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            var expiredRefreshToken = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]));
            await _accountRepositpry.Acccount_Update_RefreshToken(new AccountUpdateRefreshRequestData
            {
                AccountID = user.AccountID,
                ExpiredTime = expiredRefreshToken,
                RefreshToken = newRefreshToken
            })
            ;

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
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

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;


        }
    }
}
