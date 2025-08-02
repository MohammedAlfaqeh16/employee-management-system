using asp.netCore_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace asp.netCore_project.Controllers
{
    [Authorize(Roles =ClsRolse.roleAdmin)]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public RolesController(UserManager<IdentityUser> user , RoleManager<IdentityRole> role)
        {
            _user = user;
            _role = role;
        }
        public async Task<IActionResult> Index()
        {
            var _users = await _user.Users.ToListAsync();
            return View(_users);
        }
        public async Task<IActionResult> AddRole(string userId)
        {
            var user = await _user.FindByIdAsync(userId);
            var userRoles = await _user.GetRolesAsync(user);
            var allRoles = await _role.Roles.ToListAsync();
            if(allRoles != null)
            {
                var roleList = allRoles.Select(role => new roleViewModel()
                {
                    roleId = role.Id,
                    roleName = role.Name,
                    useRole = userRoles.Contains(role.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = user.Id;
                return View(roleList);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string userId, string jsonRoles)
        {
            var user = await _user.FindByIdAsync(userId);

            List<roleViewModel> myRoles =
                JsonConvert.DeserializeObject<List<roleViewModel>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _user.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _user.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _user.AddToRoleAsync(user, role.roleName.Trim());
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }




    
}
