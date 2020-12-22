using System;
using System.Drawing;

namespace TRPZ_PrintService.Data
{
    public class Printer
    {
        public int PrinterId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int ExtruderCount { get; set; }
        public int MaxTemp { get; set; }
        public int BuildPlateLength { get; set; }
        public int BuildPlateWidth { get; set; }
    }
}