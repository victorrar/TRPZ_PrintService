using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Areas.Identity.Data;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class ManageOrders : PageModel
    {
        private readonly TRPZ_PrintServiceContext _context;
        private UserManager<TRPZ_PrintServiceUser> _userManager;

        public ManageOrders(TRPZ_PrintServiceContext context, UserManager<TRPZ_PrintServiceUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Order> Orders { get; set; }

        public async Task<IActionResult> OnGet(string? type)
        {
            type ??= "all";
            if (type == "unprocessed")
                Orders = await _context.Orders
                    .Include(order => order.Client)
                    .Include(order => order.Models)
                    .ThenInclude(order => order.PostProcessing)
                    .Where(order => order.Status == Order.OrderStatus.Sent ||
                                    order.Status == Order.OrderStatus.Confirmed)
                    .OrderByDescending(order => order.Timestamp)
                    .ToListAsync();
            if (type == "all")
                Orders = await _context.Orders
                    .Include(order => order.Client)
                    .Include(order => order.Models)
                    .ThenInclude(order => order.PostProcessing)
                    .Where(order => order.Status != Order.OrderStatus.NotSent)
                    .OrderByDescending(order => order.Timestamp)
                    .ToListAsync();


            return Page();
        }

        public async Task<IActionResult> OnPostSetStatus(int orderId, string status, string returnUrl)
        {
            var order = _context.Orders.Find(orderId);
            if (status == "not_sent")
                order.Status = Order.OrderStatus.NotSent;
            if (status == "sent")
                order.Status = Order.OrderStatus.Sent;
            if (status == "confirmed")
                order.Status = Order.OrderStatus.Confirmed;
            if (status == "finished")
                order.Status = Order.OrderStatus.Finished;
            if (status == "cancelled")
                order.Status = Order.OrderStatus.Cancelled;


            _context.SaveChanges();
            var a = Request.Headers["Referer"].ToString();
            return Redirect(a);
            // return new RedirectToPageResult("/ManageOrders", "");
        }
    }
}