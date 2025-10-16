namespace AnomalyDetection.Models
{
    public class SalesOutput
    {
        public double[] Prediction { get; set; } // [alert, score, p-value]
        public string OrgName { get; set; }
        public string StoreName { get; set; }


    }
}
