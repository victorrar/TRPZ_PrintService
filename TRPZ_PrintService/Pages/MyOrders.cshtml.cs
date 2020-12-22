using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Data;


namespace TRPZ_PrintService.Pages
{
    public class MyOrders : PageModel
    {
        private TRPZ_PrintServiceContext _context;

        [BindProperty] public List<Order> Orders { get; set; }

        public MyOrders(TRPZ_PrintServiceContext context)
        {
            _context = context;
        }

        public void OnGet(string? id)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);

            Orders = _context.Orders.Include(order => order.Models).Where(order => order.Client.Id == id).ToList();
        }

        public async Task<IActionResult> OnPostSend(string? id, int orderId)
        {
            id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Orders.Find(orderId);
            order.IsSent = true;
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
            if (order == null)
            {
                return NotFound();
            }

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