namespace AnomalyDetection.Models
{
    public class SalesInput
    {
        public float Sales { get; set; }
        public float Multiplier { get; set; }
        public string Severity { get; set; }
        public string OrgName { get; set; }          // SQL nvarchar
        public string StoreName { get; set; }

    }
}
