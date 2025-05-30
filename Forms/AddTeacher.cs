using student_scoringV2.Classes;
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
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
            LoadDepartments(); // Load departments when form initializes
        }

        // Load departments into combobox
        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT id, department_name FROM departments";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    // Set up the ComboBox
                    cb_departmentid.DataSource = dt;
                    cb_departmentid.DisplayMember = "department_name"; // What to show to the user
                    cb_departmentid.ValueMember = "id";                // What to use as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_fname.Text))
            {
                MessageBox.Show("Please enter First Name.");
                tb_fname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_lname.Text))
            {
                MessageBox.Show("Please enter Last Name.");
                tb_lname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_address.Text))
            {
                MessageBox.Show("Please enter Address.");
                tb_address.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_pnumber.Text))
            {
                MessageBox.Show("Please enter Phone Number.");
                tb_pnumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_email.Text))
            {
                MessageBox.Show("Please enter Email.");
                tb_email.Focus();
                return;
            }
            if (cb_departmentid.SelectedValue == null)
            {
                MessageBox.Show("Please select a Department.");
                cb_departmentid.Focus();
                return;
            }

            try
            {
                string insert = @"INSERT INTO teachers (department_id, first_name, last_name, phone_number, address, created_by, email) 
                                VALUES (@department_id, @first_name, @last_name, @phone_number, @address, @created_by, @email)";

                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                    cmd.Parameters.AddWithValue("@first_name", tb_fname.Text);
                    cmd.Parameters.AddWithValue("@last_name", tb_lname.Text);
                    cmd.Parameters.AddWithValue("@address", tb_address.Text);
                    cmd.Parameters.AddWithValue("@phone_number", tb_pnumber.Text);
                    cmd.Parameters.AddWithValue("@created_by", Session.LoginUserId);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Teacher added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                tb_fname.Clear();
                tb_lname.Clear();
                tb_address.Clear();
                tb_pnumber.Clear();
                tb_email.Clear();
                cb_departmentid.SelectedIndex = -1; // Reset department selection
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }
    }
}