using CronosAgency.Data;
using CronosAgency.Models;
using CronosAgency.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CronosAgency.Controllers.Admin
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly CronosAgencyContext _context;

        public LoginController(CronosAgencyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Admin");
            }

            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _context.Users.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Admin");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Password == model.ConfirmPassword)
            {
                User user = new User();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = model.Password;
                user.CreateDate = new System.DateTime();
                user.LastTimePasswordChanged = new System.DateTime();
                var result = await _context.Users.AddAsync(user);

                if (result != null)
                {
                    return RedirectToAction("index", "home");
                }
            }

            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
