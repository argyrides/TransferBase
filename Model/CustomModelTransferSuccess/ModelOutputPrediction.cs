using Microsoft.ML.Data;

namespace TransferBase.Model.CustomModelTransferSuccess
{
    public class ModelOutputPrediction
    {
        [ColumnName(@"Score")]
        public float Score { get; set; }
    }
}
