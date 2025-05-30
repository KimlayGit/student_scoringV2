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
    public partial class AddRole : Form
    {
        public AddRole()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_rolename.Text))
            {
                MessageBox.Show("Please enter a Role Name.");
                tb_rolename.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_code.Text))
            {
                MessageBox.Show("Please enter a Short Code.");
                tb_code.Focus();
                return;
            }
            try
            {
                string insert = @"INSERT INTO roles (role_name, code) VALUES (@role_name, @code)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@role_name",tb_rolename.Text);
                    cmd.Parameters.AddWithValue("@code", tb_code.Text);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Role added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                tb_rolename.Clear();
                tb_code.Clear();
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
