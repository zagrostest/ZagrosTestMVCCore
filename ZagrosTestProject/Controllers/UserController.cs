using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCookieAuthentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZagrosTestProject.Common;
using ZagrosTestProject.ViewModels;

namespace ZagrosTestProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private Entities.ASPCoreDBContext _context;
        public UserController(Entities.ASPCoreDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var hashPassword = EncryptionUtility.HashSHA256(model.Password);
            var user = new Users
            {
                FirstName = model.FirstName,
                IsActive = true,
                LastName = model.LastName,
                Password = hashPassword,
                UserName = model.UserName
            };
            await _context.AddAsync<Users>(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}