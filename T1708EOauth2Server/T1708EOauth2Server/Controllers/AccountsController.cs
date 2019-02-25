using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityHelper;
using T1708EOauth2Server.Data;
using T1708EOauth2Server.Models;

namespace T1708EOauth2Server.Controllers
{
    public class AccountsController : Controller
    {
        private readonly T1708EOauth2ServerContext _context;

        public AccountsController(T1708EOauth2ServerContext context)
        {
            _context = context;
        }

        public IActionResult Login(string redirectUrl)
        {
            ViewData["redirectUrl"] = redirectUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            var existAccount = _context.Account.SingleOrDefault(a => a.Email == account.Email);
            if (existAccount != null)
            {                             
                if (existAccount.Password == SecurityHelper.PasswordHandle.GetInstance().EncryptPassword(account.Password, existAccount.Salt))
                {
                    Request.HttpContext.Session.SetString("loggedUserEmail", existAccount.Email);
                    Request.HttpContext.Session.SetString("loggedUserId", existAccount.Id.ToString());
                    
                    return Redirect("/Home/About");
                }
            }
            // nếu người dùng đăng nhập thành công thì tạo session mới cho người dùng. 
            // Chính là thông tin tài khoản vừa đăng nhập.
            return View(account);
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Account.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,ConfirmPassword,UserInformation")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.Salt = SecurityHelper.PasswordHandle.GetInstance().GenerateSalt();
                account.Password = SecurityHelper.PasswordHandle.GetInstance()
                    .EncryptPassword(account.Password, account.Salt);
                _context.Add(account);
                _context.Add(account.UserInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.Include(a => a.UserInformation).FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Email,Password,ConfirmPassword,UserInformation")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    account.Salt = SecurityHelper.PasswordHandle.GetInstance().GenerateSalt();
                    account.Password = SecurityHelper.PasswordHandle.GetInstance()
                        .EncryptPassword(account.Password, account.Salt);
                    _context.Update(account);
                    _context.Update(account.UserInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(long id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
    }
}
