using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using T1708EOauth2Server.Data;
using T1708EOauth2Server.Models;

namespace T1708EOauth2Server.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly T1708EOauth2ServerContext _context;
        private IMemoryCache _cache;

        private readonly Dictionary<int, CredentialScope> _credentialScopes = new Dictionary<int, CredentialScope>()
        {
            {
                1,
                new CredentialScope()
                {
                    Id = 1,
                    Name = "Basic",
                    Icon = "https://cdn4.iconfinder.com/data/icons/eldorado-mobile/40/info_3-128.png",
                    Description = "Mô tả ngắn gọn về quyền ở trên."
                }

            },
            {
                2,
                new CredentialScope()
                {
                    Name = "Song",
                    Icon = "https://cdn3.iconfinder.com/data/icons/watchify-v1-0-32px/32/music-note-128.png",
                    Description = "Quản lý thông tin bài hát của người dùng."
                }

            },
            {
                3,
                new CredentialScope()
                {
                    Name = "Photo",
                    Icon = "http://icons.iconarchive.com/icons/designcontest/outline/256/Camera-icon.png",
                    Description = "Quản lý thông tin photo."
                }

            }

        };
        public AuthorizationController(T1708EOauth2ServerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public IActionResult Consent(int clientId, string scopes)
        {
            // Kiểm tra người dùng đăng nhập chưa
            var loggedEmail = HttpContext.Session.GetString("loggedUserEmail");
            var loggedIdString = HttpContext.Session.GetString("loggedUserId");
            long loggedId = 0;
            try
            {
                loggedId = Int64.Parse(loggedIdString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var currentAccount = _context.Account.SingleOrDefault(a => a.Id == loggedId);

            if (currentAccount == null)
            {
                // Đưa người dùng sang trang đăng nhập
                return Redirect("/Accounts/Login?redirectUrl=" +  WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }

            var currentApp = _context.RegisterApplication.SingleOrDefault(ra => ra.Id == clientId);
            if (currentApp == null)
            {
                Response.StatusCode = (int)(HttpStatusCode.Forbidden);
                return new JsonResult(HttpStatusCode.Forbidden.ToString());         
            }

            var scopeIds = scopes.Split(",");
            List<CredentialScope> listRequestScopes = new List<CredentialScope>();
            foreach (var strId in scopeIds)
            {
                var id = Int32.Parse(strId);
                if (!_credentialScopes.ContainsKey(id))
                {
                    Response.StatusCode = (int)(HttpStatusCode.NotFound);
                    return new JsonResult(HttpStatusCode.NotFound.ToString());
                }
                listRequestScopes.Add(_credentialScopes[id]);
            }

            ViewData["redirectUrl"] = Request.GetDisplayUrl();
            ViewData["currentApp"] = currentApp;
            ViewData["listRequestScopes"] = listRequestScopes;
            ViewData["scopes"] = scopes;
            return View();
        }
        [HttpPost]
        public IActionResult PostConsent(int clientId, string scopes, string redirectUrl)
        {
            // Kiểm tra người dùng đăng nhập chưa
            var loggedEmail = HttpContext.Session.GetString("loggedUserEmail");
            var loggedIdString = HttpContext.Session.GetString("loggedUserId");
            long loggedId = 0;
            try
            {
                loggedId = Int64.Parse(loggedIdString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var currentAccount = _context.Account.SingleOrDefault(a => a.Id == loggedId);

            if (currentAccount == null)
            {
                // Đưa người dùng sang trang đăng nhập
                return Redirect("/Accounts/Login?redirectUrl=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }

            var currentApp = _context.RegisterApplication.SingleOrDefault(ra => ra.Id == clientId);
            if (currentApp == null)
            {
                Response.StatusCode = (int)(HttpStatusCode.Forbidden);
                return new JsonResult(HttpStatusCode.Forbidden.ToString());
            }

            var scopeIds = scopes.Split(",");
            List<CredentialScope> listRequestScopes = new List<CredentialScope>();
            foreach (var strId in scopeIds)
            {
                var id = Int32.Parse(strId);
                if (!_credentialScopes.ContainsKey(id))
                {
                    Response.StatusCode = (int)(HttpStatusCode.NotFound);
                    return new JsonResult(HttpStatusCode.NotFound.ToString());
                }
            }

            // Tạo credential lưu vào database với status deactive
            var credential = new Credential(currentAccount.Id, scopes);
            credential.Status = CredentialStatus.Deactive;
            _context.Credential.Add(credential);
            _context.SaveChanges();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
            // Keep in cache for this time, reset time if accessed.
            .SetSlidingExpiration(TimeSpan.FromSeconds(5));
            AuthorizationCode authorizationCode = new AuthorizationCode(credential);

            // Tạo authorization code có liên kết với credential vừa tạo
            _cache.Set(authorizationCode.Code, authorizationCode, cacheEntryOptions);

            // Đưa người dùng về redirectUrl kèm theo
            return Redirect(currentApp.RedirectUrl + "?exchange-code=" + authorizationCode.Code);
        }

    }
}