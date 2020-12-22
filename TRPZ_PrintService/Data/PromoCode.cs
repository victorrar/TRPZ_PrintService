using System;
using System.Collections.Generic;

namespace TRPZ_PrintService.Data
{
    public class PromoCode
    {
        public int PromoCodeId { get; set; }
        public DateTime Issue { get; set; }
        public DateTime ActiveTo { get; set; }
        public int Count { get; set; } //0 - unlimited
        public int Discount { get; set; }

        public List<Order> Orders { get; set; }
    }
}