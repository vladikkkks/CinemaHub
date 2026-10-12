using System;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace CinemaHub.Reports
{
    public class FinancialAnalytics
    {
        public ReportDocument CreateFinancialReport(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=CinemaHub_DB;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Формування багатотабличного JOIN-запиту з агрегацією[cite: 20]
                string sql = @"
                    SELECT g.GenreName, m.Title, COUNT(t.TicketID) AS TotalTicketsSold, SUM(s.TicketPrice) AS TotalRevenue
                    FROM Genres g
                    INNER JOIN Movies m ON g.GenreID = m.GenreID
                    INNER JOIN Sessions s ON m.MovieID = s.MovieID
                    INNER JOIN Tickets t ON s.SessionID = t.SessionID
                    WHERE t.PurchaseDate >= @FromDate AND t.PurchaseDate <= @ToDate
                    GROUP BY g.GenreName, m.Title";
                
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Ініціалізація документа Crystal Reports[cite: 19]
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(@"Reports\FinancialAnalyticsReport.rpt");
            rptDoc.SetDataSource(dt); // Передача DataTable у документ[cite: 19]
            
            // Передача параметрів періоду у заголовок звіту[cite: 20]
            rptDoc.SetParameterValue("ParamPeriodFrom", fromDate.ToShortDateString());
            rptDoc.SetParameterValue("ParamPeriodTo", toDate.ToShortDateString());
            
            return rptDoc;
        }
    }
}