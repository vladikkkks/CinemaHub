using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace CinemaHub.Reports
{
    public class TicketGenerator
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CinemaHub_DB;Trusted_Connection=True;";

        public LocalReport GenerateTicketReport(int ticketId)
        {
            DataTable ticketData = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM vw_TicketDetails WHERE TicketID = @TicketID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TicketID", ticketId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ticketData); // Отримання даних з бази[cite: 17]
            }

            LocalReport report = new LocalReport();
            report.ReportPath = "Reports/TicketReport.rdlc";
            // Передача джерела даних у RDLC (Push Model)[cite: 2, 17]
            report.DataSources.Add(new ReportDataSource("TicketDataSet", ticketData)); 
            
            return report;
        }
    }
}