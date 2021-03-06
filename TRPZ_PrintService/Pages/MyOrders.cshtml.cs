using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Pages
{
    public class MyOrders : PageModel
    {
        private readonly TRPZ_PrintServiceContext _context;

        public MyOrders(TRPZ_PrintServiceContext context)
        {
            _context = context;
        }

        [BindProperty] public List<Order> Orders { get; set; }

        public void OnGet(string? id)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);

            Orders = _context.Orders
                .Include(order => order.Models)
                .ThenInclude(order => order.PostProcessing)
                .Where(order => order.Client.Id == id)
                .OrderByDescending(order => order.Timestamp)
                .ToList();
        }

        public async Task<IActionResult> OnPostSend(string? id, int orderId)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Orders.Find(orderId);
            order.Status = Order.OrderStatus.Sent;
            await _context.SaveChangesAsync();

            return new RedirectToPageResult("/MyOrders", "");
        }

        public async Task<IActionResult> OnPostCancel(string? id, int orderId)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Orders.Find(orderId);
            order.Status = Order.OrderStatus.Cancelled;
            await _context.SaveChangesAsync();

            return new RedirectToPageResult("/MyOrders", "");
        }

        public IActionResult OnPostCreate(string? id)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = new Order();
            order.Timestamp = DateTime.Now;
            order.Client = _context.Users.First(user => user.Id == id);

            _context.Orders.Add(order);
            _context.SaveChanges();
            return new RedirectToPageResult("/MyOrders");
        }

        public IActionResult OnPostRemove(string? id, int? orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null) return NotFound();

            try
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new RedirectToPageResult("/MyOrders");
        }
    }
}