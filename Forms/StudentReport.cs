using Microsoft.Reporting.WinForms;
using student_scoringV2.ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class StudentReport : Form
    {
        public StudentReport()
        {
            InitializeComponent();
            LoadReportData();
        }
        private void LoadReportData()
        {
            // 1. Get data
            DataTable scoresData = GetScoreData();

            // 2. Configure ReportViewer
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("StudentScoreDataset", scoresData));

            // 3. Refresh
            reportViewer1.RefreshReport();
        }
        private DataTable GetScoreData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Connectiondb.GetConnection())
            {
                string query = @"SELECT 
                        st.first_name + ' ' + st.last_name AS student_name,
                        c.course_name,
                        s.score_value,
                        s.maximum_score,
                        s.percentage,
                        s.grade_letter,
                        FORMAT(s.date_recorded, 'MM/dd/yyyy') AS date_recorded
                        FROM scores s
                        JOIN students st ON s.student_id = st.id
                        JOIN courses c ON s.course_id = c.id";

                new SqlDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }
        private void StudentReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
