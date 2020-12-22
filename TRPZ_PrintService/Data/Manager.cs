using System;
using System.Collections.Generic;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Data
{
    public class Manager : TRPZ_PrintServiceUser
    {
        public String Type { get; set; }
        public List<ModelInOrder> ModelsInOrders { get; set; }
    }
}