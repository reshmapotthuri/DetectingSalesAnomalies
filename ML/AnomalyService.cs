using AnomalyDetection.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AnomalyDetection.ML
{
    public class AnomalyService
    {
        const string connStrMLDB = @"Server=localhost\MSSQLSERVER02;Database=MLDataDB;Integrated Security=true;";
        public static List<AnomalyPoint> Detect()
        {
            var mlContext = new MLContext();
            try
            {
                var loader = mlContext.Data.CreateDatabaseLoader<SalesInput>();
                var dbSource = new DatabaseSource(SqlClientFactory.Instance, connStrMLDB,
                    "SELECT CAST(Sales AS REAL) AS Sales,CAST(Multiplier AS REAL) AS Multiplier,Severity,OrgName,StoreName FROM vw_SalesAnomaly");
                //"SELECT Sales, Multiplier, Severity FROM vw_SalesAnomaly");


                var dataView = loader.Load(dbSource);
                var pipeline = mlContext.Transforms.DetectIidSpike(
                    outputColumnName: nameof(SalesOutput.Prediction),
                    inputColumnName: nameof(SalesInput.Sales),
                    confidence: 95,
                    pvalueHistoryLength: 30)
                     .Append(mlContext.Transforms.CopyColumns("OrgName", "OrgName"))
                    .Append(mlContext.Transforms.CopyColumns("StoreName", "StoreName"));


                var model = pipeline.Fit(dataView);
                var transformed = model.Transform(dataView);

                var results = mlContext.Data.CreateEnumerable<SalesOutput>(transformed, reuseRowObject: false)
                        .Select((p, index) => new AnomalyPoint
                        {
                            Index = index,
                            Score = p.Prediction[1],
                            PValue = p.Prediction[2],
                            IsAnomaly = p.Prediction[0] == 1,
                            OrgName = p.OrgName,
                            StoreName = p.StoreName
                        }).ToList();
                return results;
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                throw;
            }

           
        }

    }
}
