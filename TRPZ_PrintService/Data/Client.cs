using System.Collections.Generic;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Data
{
    public class Client : TRPZ_PrintServiceUser
    {
        public List<Order> Orders { get; set; }

        public Client()
        {
            Orders = new List<Order>();
        }
    }
}