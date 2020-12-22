using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRPZ_PrintService.Data
{
    public class ModelInOrder
    {
        public int ModelInOrderId { get; set; }
        public double Scale { get; set; }
        public bool HasSolubleSupports { get; set; } //restricts usage only on multi-material printers
        public int PriceTotal { get; set; }

        public Order Order { get; set; }
        public ModelSettings ModelSettings { get; set; }
        public Material Material { get; set; }
        public PostProcessing PostProcessing { get; set; }
        public Manager Manager { get; set; }
        public Printer Printer { get; set; }
        public Model3D Model { get; set; }

        public ModelInOrder()
        {
            Scale = 1;
        }

        public override string ToString()
        {
            return Model.Description;
        }
    }
}