using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RolesManager.Data;

namespace RolesManager.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        private ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new IdentityRole());
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View(new IdentityRole());
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IdentityRole role)
        {
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }


    }
}
