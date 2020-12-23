using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRPZ_PrintService.Areas.Identity.Data;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class ManageStaff : PageModel
    {
        private TRPZ_PrintServiceContext _context;
        private readonly UserManager<TRPZ_PrintServiceUser> _userManager;


        public ManageStaff(TRPZ_PrintServiceContext context, UserManager<TRPZ_PrintServiceUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<UserRole> UsersRoles { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var users = _userManager.Users.OrderBy(user => user.Id).ToList();
            UsersRoles = new List<UserRole>();

            users.ForEach(user =>
            {
                var r = _userManager.GetRolesAsync(user);
                r.Wait();
                UsersRoles.Add(new UserRole
                {
                    roles = r.Result,
                    user = user
                });
            });

            return Page();
        }

        public async Task<IActionResult> OnPostSetRole(string userId, string role)
        {
            var user = _userManager.Users.First(serviceUser => serviceUser.Id == userId);
            var roles = await _userManager.GetRolesAsync(user);

            if (role == "Admin")
            {
                await _userManager.RemoveFromRoleAsync(user, "Manager");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            if (role == "Manager")
                // await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "Manager");

            if (role == "Client")
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.RemoveFromRoleAsync(user, "Manager");
                await _userManager.AddToRoleAsync(user, "Client");
            }

            return new RedirectToPageResult("/ManageStaff", "");
        }

        public async Task<IActionResult> OnPostDelete(string userId)
        {
            var user = _userManager.Users.First(serviceUser => serviceUser.Id == userId);
            await _userManager.DeleteAsync(user);


            return new RedirectToPageResult("/ManageStaff", "");
        }

        public class UserRole
        {
            public TRPZ_PrintServiceUser user { get; set; }
            public IList<string> roles { get; set; }
        }
    }
}