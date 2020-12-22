using System;
using System.Collections.Generic;

namespace TRPZ_PrintService.Data
{
    public class PostProcessing
    {
        public int PostProcessingId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }

        public List<ModelInOrder> ModelsInOrders { get; set; }
    }
}