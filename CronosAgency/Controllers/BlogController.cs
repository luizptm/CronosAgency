using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosAgency.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
