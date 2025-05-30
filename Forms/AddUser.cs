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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                string query = "SELECT id, role_name FROM roles ORDER BY role_name";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    // Set up the ComboBox
                    cb_role.DataSource = dt;
                    cb_role.DisplayMember = "role_name"; // What to show to the user
                    cb_role.ValueMember = "id";       // What to use as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_email.Text))
            {
                MessageBox.Show("Please enter Email.");
                tb_email.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_username.Text))
            {
                MessageBox.Show("Please enter Username.");
                tb_username.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_password.Text))
            {
                MessageBox.Show("Please enter Password.");
                tb_password.Focus();
                return;
            }
            try
            {
                string insert = @"INSERT INTO users (role_id, email, username, password) VALUES (@role_id, @email, @username, @password)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@role_id", cb_role.SelectedValue);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);
                    cmd.Parameters.AddWithValue("@username", tb_username.Text);
                    cmd.Parameters.AddWithValue("@password", tb_password.Text);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("User added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                tb_email.Clear();
                tb_username.Clear();
                tb_password.Clear();
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
