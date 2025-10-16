namespace AnomalyDetection.Models
{
    public class AnomalyPoint
    {
        public int Index { get; set; }
        public double Score { get; set; }
        public double PValue { get; set; }
        public bool IsAnomaly { get; set; }
        public string OrgName { get; set; }          // SQL nvarchar
        public string StoreName { get; set; }

    }
}
