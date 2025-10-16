using AnomalyDetection.ML;
using AnomalyDetection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnomalyDetection.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        public List<AnomalyPoint> results { get; set; }
        public int AnomalyCount { get; set; }
        public int OrgCount { get; set; }
        public int StoreCount { get; set; } 
        public List<string> StoreList { get; set; }
        public List<string> OrgList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedStore { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedOrg {get; set; }
        public int TotalRecords { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

        }

        public void OnGet()
        {
            results = AnomalyService.Detect();
            if (!string.IsNullOrEmpty(SelectedStore))
            {
                results = results.Where(x => x.StoreName == SelectedStore).ToList();
            }
            if (!string.IsNullOrEmpty(SelectedOrg))
            {
                results = results.Where(x => x.OrgName == SelectedOrg).ToList();
            }
            AnomalyCount = results.Count(x=>x.IsAnomaly);
            OrgCount = results.Where(r => r.IsAnomaly).Select(r => r.OrgName).Distinct().ToList().Count();
            StoreCount = results.Where(r => r.IsAnomaly).Select(r => r.StoreName).Distinct().ToList().Count();
            StoreList = results.Select(x => x.StoreName).ToList();
            OrgList = results.Select(x => x.OrgName).ToList();
            TotalRecords = results.Distinct().ToList().Count();
        }
    }
}
