using System.Data.SqlClient;
using CinemaHub.Models;

namespace CinemaHub.Controllers
{
    // Розробник: Владислав Прус
    public class AccountController
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CinemaHub_DB;Trusted_Connection=True;";

        public bool Login(string email, string password, string role)
        {
            // У реальному проєкті паролі хешуються. Це спрощений базовий приклад.
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password AND Role = @Role";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);
                
                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }
    }
}