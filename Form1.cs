using student_scoringV2.Classes;
using student_scoringV2.ConnectionDB;
using student_scoringV2.Forms;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace student_scoringV2
{
    public partial class mainfrm : Form
    {
        public mainfrm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            //string username = "admin";
            //string password = "123";
            string query = "SELECT * FROM users Where username = @username AND password = @password";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", tb_username.Text);
                cmd.Parameters.AddWithValue("@password", tb_password.Text);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["id"]);
                        string username = reader["username"].ToString();

                        Session.LoginUserId = userId;
                        Session.LoginUsername = username;

                        MessageBox.Show("Login Successfully");
                        this.Hide();
                        Mainboard mainboard = new Mainboard();
                        mainboard.Username = username;
                        mainboard.Show();
                    }
                    else
                    {
                        // User not found, show error message
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
            }
        }

        private void btn_login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e);
            }
        }
    }
}
