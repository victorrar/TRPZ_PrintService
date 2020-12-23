using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Data
{
    public class Order
    {
        public enum OrderStatus
        {
            NotSent,
            Sent,
            Confirmed,
            Finished,
            Cancelled
        }

        public Order()
        {
            Models = new List<ModelInOrder>();
        }

        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public TimeSpan TotalPrintTime { get; set; }
        public OrderStatus Status { get; set; }

        public TRPZ_PrintServiceUser Client { get; set; }
        public PromoCode PromoCode { get; set; }

        public List<ModelInOrder> Models { get; set; }

        [NotMapped]
        public int PriceTotal
        {
            get { return Models.Sum(x => x.PriceTotal) + Models.Sum(x => x.PostProcessing.Price); }
        }
    }
}