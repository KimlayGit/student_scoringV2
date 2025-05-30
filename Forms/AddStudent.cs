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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void LoadClassData()
        {
            string sql = "SELECT id, class_name FROM classes";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cb_class.DataSource = dt;
                cb_class.DisplayMember = "class_name"; // Display the class name
                cb_class.ValueMember = "id"; // Use the class ID as the value
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tb_firstname.Text))
            {
                MessageBox.Show("Please enter the First Name.");
                tb_firstname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_lastname.Text))
            {
                MessageBox.Show("Please enter the Last Name.");
                tb_lastname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_email.Text))
            {
                MessageBox.Show("Please enter the Email.");
                tb_email.Focus();
                return;
            }
            if (cb_gender.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Your Gender.");
                cb_gender.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_phonenumber.Text))
            {
                MessageBox.Show("Please enter the Phone Number.");
                tb_phonenumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_address.Text))
            {
                MessageBox.Show("Please enter the Address.");
                tb_address.Focus();
                return;
            }
            DateTime selecteddob = dtp_dob.Value;
            string formattedDate = selecteddob.ToString("yyyy-MM-dd");
            dtp_dob.Text = formattedDate;


            DateTime selectedEmrollment = dtp_enrollment.Value;
            string formattedEnrollment = selectedEmrollment.ToString("yyyy-MM-dd");
            dtp_enrollment.Text = formattedEnrollment;
            try 
            {
                string sql = @"Insert into students (class_id, first_name, last_name, dob, gender, phone_number, email, address, enrollment_date) Values (@class_id, @first_name, @last_name, @dob, @gender, @phone_number, @email, @address ,@enrollment_date)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@class_id", cb_class.SelectedValue); // Assuming cb_class is a ComboBox with class IDs
                    cmd.Parameters.AddWithValue("@first_name", tb_firstname.Text);
                    cmd.Parameters.AddWithValue("@last_name", tb_lastname.Text);
                    cmd.Parameters.AddWithValue("@dob", formattedDate);
                    cmd.Parameters.AddWithValue("@gender", cb_gender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@phone_number", tb_phonenumber.Text);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);
                    cmd.Parameters.AddWithValue("@address", tb_address.Text);
                    cmd.Parameters.AddWithValue("@enrollment_date", formattedEnrollment);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Student added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }
                // Clear fields
                tb_firstname.Clear();
                tb_lastname.Clear();
                tb_address.Clear();
                cb_gender.SelectedIndex = 0;
                tb_email.Clear();
                tb_phonenumber.Clear();
                dtp_dob.Value = DateTime.Now; // Reset to current date
                cb_gender.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the student: " + ex.Message);
                return;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Mainboard mainboard = new Mainboard();
            this.Hide();
            mainboard.Show();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            this.cb_gender.Items.Add("Male");
            this.cb_gender.Items.Add("Female");
            this.cb_gender.Items.Add("Others");

            LoadClassData();
        }
    }
}
