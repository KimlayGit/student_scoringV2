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
    public partial class AddDepartment : Form
    {
        public AddDepartment()
        {
            InitializeComponent();
        }
        private void LoadTeacher()
        {
            try
            {
                string query = "SELECT id, first_name +' '+last_name as full_name FROM teachers";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    // Set up the ComboBox
                    cb_headofdepartment.DataSource = dt;
                    cb_headofdepartment.DisplayMember = "full_name"; // What to show to the user
                    cb_headofdepartment.ValueMember = "id";       // What to use as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Teacher: " + ex.Message);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_departmentname.Text))
            {
                MessageBox.Show("Please enter Department Name.");
                tb_departmentname.Focus();
                return;
            }
            try
            {
                string insert = @"INSERT INTO departments (head_of_department, department_name, code) VALUES (@head_of_department, @department_name, @code)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    object headValue = cb_headofdepartment.SelectedValue ?? (object)DBNull.Value;
                    cmd.Parameters.AddWithValue("head_of_department", headValue);
                    cmd.Parameters.AddWithValue("department_name", tb_departmentname.Text);
                    cmd.Parameters.AddWithValue("code", tb_code.Text);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Department added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                tb_departmentname.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            LoadTeacher();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }
    }
}
