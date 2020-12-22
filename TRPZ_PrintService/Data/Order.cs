using System;
using System.Collections.Generic;

namespace TRPZ_PrintService.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public TimeSpan TotalPrintTime { get; set; }
        public bool IsSent { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsFinished { get; set; }

        public Client Client { get; set; }
        public PromoCode PromoCode { get; set; }

        public List<ModelInOrder> Models { get; set; }

        public Order()
        {
            Models = new List<ModelInOrder>();
        }
    }
}