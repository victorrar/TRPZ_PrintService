using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRPZ_PrintService.Areas.Identity.Data;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class ManageOrders : PageModel
    {
        private TRPZ_PrintServiceContext _context;
        private UserManager<TRPZ_PrintServiceUser> _userManager;
        
        public ManageOrders(TRPZ_PrintServiceContext context, UserManager<TRPZ_PrintServiceUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            return new RedirectToPageResult("/ManageStaff", "");
        }
    }
}