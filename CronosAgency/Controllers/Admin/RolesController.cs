using CronosAgency.Models;
using CronosAgency.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CronosAgency.Controllers.Admin
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/roles")]
    [Authorize]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;

        public RolesController(
            UserManager<ApplicationUser> userManager,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Roles
        public IActionResult Index()
        {
            return View();
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role com Id = {id} não foi localizada";
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            var listaUsuarios = userManager.Users.ToList();
            foreach (var user in listaUsuarios)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.Email);
                }
            }
            return View(model);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name
                };

                Microsoft.AspNetCore.Identity.IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Localiza a role pelo ID
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role com Id = {id} não foi localizada";
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            var listaUsuarios = userManager.Users.ToList();
            // Retorna todos os usuários
            foreach (var user in listaUsuarios)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.Email);
                }
            }
            return View(model);
        }

        // PUT: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Role model)
        {
            var role = await roleManager.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role com Id = {model.Id} não foi encontrada";
                return View("NotFound");
            }
            else
            {
                role.Name = model.Name;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id);
        }

        // DELETE: Roles/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role com Id = {id} não foi encontrada";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListRoles");
            }
        }
    }
}
