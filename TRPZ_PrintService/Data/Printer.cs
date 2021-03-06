namespace TRPZ_PrintService.Data
{
    public class Printer
    {
        public int PrinterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExtruderCount { get; set; }
        public int MaxTemp { get; set; }
        public int BuildPlateLength { get; set; }
        public int BuildPlateWidth { get; set; }
    }
}