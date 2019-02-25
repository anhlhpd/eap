using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T1708EOauth2Server.Models;
using T1708EOauth2Server.Data;
using Microsoft.Extensions.Caching.Memory;

namespace T1708EOauth2Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly T1708EOauth2ServerContext _context;
        private IMemoryCache _cache;

        public AuthenticationController(T1708EOauth2ServerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        [HttpPost("exchange-code")]
        public IActionResult ExchangeToken(AuthorizationCode exchangeCode)
        {
            if (string.IsNullOrEmpty(exchangeCode.Code))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(HttpStatusCode.BadRequest.ToString());
            }
            if (_cache.TryGetValue(exchangeCode, out AuthorizationCode authorizationCode))
            {
                var credential = _context.Credential.SingleOrDefault(c => c.AccessToken == authorizationCode.Credential.AccessToken);
                if (credential == null)
                {
                    credential.Status = CredentialStatus.Active;
                    _context.Credential.Add(credential);
                    _context.SaveChanges();
                    _cache.Remove(authorizationCode.Code);
                    return new JsonResult(credential);
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult(HttpStatusCode.BadRequest.ToString());
        }

        public IActionResult CheckToken(string accessToken)
        {
           var credential = _context.Credential.SingleOrDefault(t => t.AccessToken == accessToken);
            if (credential == null || !credential.IsValid())
            {
                Response.StatusCode = (int) HttpStatusCode.Forbidden;
                return new JsonResult("Invalid token");
            }
            else
            {
                return new JsonResult(credential);
            }
        }


        // POST: api/Authentication
        [HttpPost]
        public IActionResult Login(LoginInformation account)
        {
            var loginSuccess = false;
            var existAccount = _context.Account.SingleOrDefault(a => a.Email == account.Email);
            if (existAccount != null)
            {
                if (existAccount.Password == SecurityHelper.PasswordHandle.GetInstance().EncryptPassword(account.Password, existAccount.Salt))
                {
                    loginSuccess = true;
                }
            }

            if (loginSuccess)
            {
                var credential = new Credential(existAccount.Id, "1");
                _context.Credential.Add(credential);
                _context.SaveChanges();
                Response.StatusCode = 200;
                return new JsonResult(credential);
            };
            Response.StatusCode = 403;
            return new JsonResult("Invalid information");
        }
       
    }
}