📊 Sales Anomaly Detection Dashboard
🚀 A modular, real-time anomaly detection dashboard built with ML.NET TimeSeries and ASP.NET Core Razor Pages. Designed for intelligent insights, recruiter-ready UX, and scalable integration with SQL Server.

🔍 Tech Highlights
- ML.NET DetectIidSpike for time-series anomaly detection
- SQL Server View vw_SalesAnomaly as the data source
- Razor Pages UI with dropdown filters for Store and Org
- LINQ-powered filtering for dynamic queries and summary counts
- Chart.js integration for visualizing spikes and trends
- Modular architecture for easy extension to other domains (e.g., inventory, demand forecasting)

🧠 How It Works
- Data Source: Sales data is aggregated via SQL Server view vw_SalesAnomaly
- ML.NET Pipeline: Detects sudden spikes using DetectIidSpike with configurable confidence and history length
- UI Layer: Razor Pages render dropdown filters, summary cards, and anomaly tables
- Filtering: LINQ dynamically filters by Store and Org, with real-time updates
- Visualization: Chart.js plots anomalies for intuitive analysis

🖥️ Screenshots

<img width="3020" height="1580" alt="Anamoly1" src="https://github.com/user-attachments/assets/2eedc59e-4567-44b2-a478-5ab3785edb7b" />
<img width="2784" height="1390" alt="Anomaly2" src="https://github.com/user-attachments/assets/a9498a5b-56e4-4ee7-b019-fc7d2e63c498" />
