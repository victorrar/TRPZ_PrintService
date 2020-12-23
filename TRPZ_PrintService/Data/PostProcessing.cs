using System.Collections.Generic;

namespace TRPZ_PrintService.Data
{
    public class PostProcessing
    {
        public int PostProcessingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<ModelInOrder> ModelsInOrders { get; set; }
    }
}