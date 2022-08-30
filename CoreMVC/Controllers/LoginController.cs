using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class LoginController : Controller
    {
        WriterManager WM = new WriterManager(new EfWriterDal());
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(Writer writer)
        {
            var result = WM.GetAll().FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (result is not null)
            {
                var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Name, writer.WriterName),
                    new Claim(ClaimTypes.Email,writer.WriterMail)
                };
                var userID = new ClaimsIdentity(claims, "MyCookie");
                ClaimsPrincipal cp = new ClaimsPrincipal(userID);
                await HttpContext.SignInAsync(cp); 
                return RedirectToAction("Home", "Blog");
            }
            else
            {
                return View();
            }
            HttpContext.Session.SetString("UserName", writer.WriterMail);
        }
    }
}
