using CronosAgency.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CronosAgency.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/home")]
    [Authorize]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly CronosAgencyContext _context;

        public HomeController(CronosAgencyContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Blog()
        {
            var data = await _context.Posts.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> QuemSomos()
        {
            var data = await _context.Members.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Servicos()
        {
            var data = await _context.Services.ToListAsync();
            return View(data);
        }
    }
}
