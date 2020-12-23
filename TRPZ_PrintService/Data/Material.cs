using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace TRPZ_PrintService.Data
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<ModelInOrder> ModelsInOrders { get; set; }

        //TODO read about validation https://docs.microsoft.com/en-us/ef/ef6/saving/validation

        public override string ToString()
        {
            return Name;
        }
    }
}