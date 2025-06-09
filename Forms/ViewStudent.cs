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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void DisplayStudent()
        {
            using (SqlConnection conn = (Connectiondb.GetConnection()))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM students", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dataGrid_student.DataSource = dt;
            }
        }

        private void SearchStudent()
        {
            string searchType = cb_class.SelectedItem?.ToString();
            string keyword = tb_seach.Text.Trim();

            if (string.IsNullOrEmpty(searchType) || string.IsNullOrEmpty(keyword))
            {
                DisplayStudent(); // Load all data if no input
                return;
            }

            using (SqlConnection conn = (Connectiondb.GetConnection()))
            {
                conn.Open();

                string query = "";

                if (searchType == "ID")
                {
                    query = "SELECT * FROM students WHERE id = @keyword";
                }
                else if (searchType == "Name")
                {
                    query = "SELECT * FROM students WHERE first_name LIKE @keyword OR last_name LIKE @keyword";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (searchType == "ID")
                    {
                        cmd.Parameters.AddWithValue("@keyword", keyword);
                    }
                    else // Name
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGrid_student.DataSource = dt;
                }
            }
        }


        private void ViewStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_Scoring_ManagementDataSet.students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.student_Scoring_ManagementDataSet.students);
            DisplayStudent();
            cb_class.Items.Add("By ID");
            cb_class.Items.Add("By Name");
        }

        private void tb_seach_TextChanged(object sender, EventArgs e)
        {
            SearchStudent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }

        private void studentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.student_Scoring_ManagementDataSet);

        }

        private void dataGrid_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_class_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
