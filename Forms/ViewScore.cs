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
    public partial class ViewScore : Form
    {
        public ViewScore()
        {
            InitializeComponent();
        }

        private void SearchStudent(string searchType, string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(searchType) || string.IsNullOrEmpty(keyword))
                {
                    LoadScore(); // Load all scores if no search input
                    return;
                }

                string query = @"
            SELECT 
                s.id,
                st.first_name + ' ' + st.last_name AS StudentName,
                c.course_name AS CourseName,
                cl.class_name AS ClassName,
                s.score_value,
                s.maximum_score,
                s.percentage,
                s.grade_letter
            FROM scores s
            JOIN students st ON s.student_id = st.id
            JOIN courses c ON s.course_id = c.id
            JOIN classes cl ON s.class_id = cl.id
            WHERE ";

                using (SqlConnection conn = Connectiondb.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (searchType == "ID")
                    {
                        // Validate ID is numeric
                        if (!int.TryParse(keyword, out int id))
                        {
                            MessageBox.Show("Please enter a valid numeric ID.");
                            return;
                        }

                        query += " st.id = @id "; // Search by student ID (assuming student id column is st.id)
                        cmd.Parameters.AddWithValue("@id", id);
                    }
                    else if (searchType == "Name")
                    {
                        // Handle searching by full name (split into first and last)
                        string[] parts = keyword.Trim().Split(' ');

                        if (parts.Length == 2)
                        {
                            query += " st.first_name LIKE @first AND st.last_name LIKE @last ";
                            cmd.Parameters.AddWithValue("@first", "%" + parts[0] + "%");
                            cmd.Parameters.AddWithValue("@last", "%" + parts[1] + "%");
                        }
                        else
                        {
                            query += " st.first_name LIKE @keyword OR st.last_name LIKE @keyword ";
                            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid search type.");
                        return;
                    }

                    cmd.CommandText = query;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgv_studentscore.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching students: " + ex.Message);
            }
        }

        private void LoadScore()
        {
            try
            {
                string query = @"
            SELECT 
    s.id,
    st.first_name + ' ' + st.last_name AS StudentName,
    c.course_name AS CourseName,
    cl.class_name AS ClassName,
    s.score_value,
    s.maximum_score,
    s.percentage,
    s.grade_letter
FROM scores s
JOIN students st ON s.student_id = st.id
JOIN courses c ON s.course_id = c.id
JOIN classes cl ON s.class_id = cl.id";
;

                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_studentscore.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scores: " + ex.Message);
            }
        }


        private void ViewScore_Load(object sender, EventArgs e)
        {
            LoadScore();
            cb_searchtype.Items.Add("ID");
            cb_searchtype.Items.Add("Name");
            cb_searchtype.SelectedIndex = 0; // Default to "ID"

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Mainboard mainForm = new Mainboard();
            mainForm.Show();
        }

        private void tb_seach_TextChanged(object sender, EventArgs e)
        {
            string searchType = cb_searchtype.SelectedItem?.ToString();
            string keyword = tb_seach.Text.Trim();

            SearchStudent(searchType, keyword);
        }
    }
}
