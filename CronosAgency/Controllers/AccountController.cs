using CronosAgency.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CronosAgency.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/account")]
    [AllowAnonymous]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly CronosAgencyContext _context;

        public AccountController(CronosAgencyContext context)
        {
            _context = context;
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Email == email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"O Email {email} já está sendo usado.");
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
