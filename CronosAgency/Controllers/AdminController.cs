using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CronosAgency.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }
    }
}
