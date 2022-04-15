using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AccountController (AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
          
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(registerVM.UserName);
            if(appUser !=null)
            {
                ModelState.AddModelError("", "This Username Is Already Exist!");

            }

            appUser.Name = registerVM.Name;
            appUser.SurName = registerVM.SurName;
            appUser.UserName = registerVM.UserName;
            appUser.Email = registerVM.Email;

            _userManager.CreateAsync(appUser, registerVM.Password);
            return RedirectToAction("index", "home");
        }
    }
}
