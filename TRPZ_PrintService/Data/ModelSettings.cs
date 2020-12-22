using System.ComponentModel.DataAnnotations.Schema;

namespace TRPZ_PrintService.Data
{
    public class ModelSettings
    {
        [ForeignKey("ModelInOrder")]
        public int ModelSettingsId { get; set; }
        public int InfillPercentage { get; set; }
        public int NozzleDiameter { get; set; }
        public int LayerHeight { get; set; }

        public ModelInOrder ModelInOrder { get; set; }
    }
}