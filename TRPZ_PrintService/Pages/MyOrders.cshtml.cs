using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
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

        public void OnGet(int? id)
        {
            var id1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Orders = _context.Orders.Where(order => order.Client.Id == id1).ToList();
        }

        public void OnPostCreate()
        {
            var order = new Order();
            order.Timestamp = DateTime.Now;
            
            var id1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.Client = _context.Clients.First(client => client.Id == id1);
            
        }
    }
}