using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CronosAgency.Controllers.Admin
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/admin")]
    [Authorize]
    [ApiController]
    public class AdministratorController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }
    }
}
