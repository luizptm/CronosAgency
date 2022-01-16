using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosAgency.Controllers
{
    public class WhoWeAreController : Controller
    {
        // GET: WhoWeAreController
        public ActionResult Index()
        {
            return View();
        }
    }
}
