using AutoMapper;
using CronosAgency.Models;
using CronosAgency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CronosAgency.Controllers.Admin
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/roles")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;
        private IMapper _mapper;

        public RolesController(
            UserManager<ApplicationUser> userManager,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._mapper = mapper; this._mapper = mapper;
        }

        // GET: Roles
        public IActionResult Index()
        {
            return View();
        }

        // GET: Roles/5
        public async Task<IActionResult> Index(int id)
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
                    var userVM = new UserViewModel();
                    userVM.Name = user.Name;
                    userVM.Email = user.Email;
                    model.Users.Add(userVM);
                }
            }
            var vm = _mapper.Map<Role>(role);
            return View(vm);
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
        public async Task<IActionResult> Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = role.Name
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
            var vm = _mapper.Map<Role>(role);
            return View(vm);
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
                    var userVM = new UserViewModel();
                    userVM.Name = user.Name;
                    userVM.Email = user.Email;
                    model.Users.Add(userVM);
                }
            }
            var vm = _mapper.Map<Role>(role);
            return View(vm);
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
                var vm = _mapper.Map<Role>(role);
                return View(vm);
            }
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await Index(id);
        }

        // POST: Roles/Delete/5
        [HttpPost]
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
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
