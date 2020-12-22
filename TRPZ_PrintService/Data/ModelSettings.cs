namespace TRPZ_PrintService.Data
{
    public class ModelSettings
    {
        public int ModelSettingsId { get; set; }
        public int InfillPercentage { get; set; }
        public int NozzleDiameter { get; set; }
        public int LayerHeight { get; set; }

        private ModelInOrder ModelInOrder { get; set; }
    }
}