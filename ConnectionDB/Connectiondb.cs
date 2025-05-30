using System.Data.SqlClient;

namespace student_scoringV2.ConnectionDB
{
    public class Connectiondb
    {
        private static readonly string ConnectionString =
            "Server=LAY\\SQLEXPRESS;Database=Student_Scoring_Management;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
