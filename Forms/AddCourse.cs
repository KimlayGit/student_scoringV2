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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace student_scoringV2.Forms
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
            LoadDepartment();

        }

        private void LoadDepartment()
        {
            string select = "Select id , department_name From departments ORDER By department_name";
            using(SqlConnection conn = Connectiondb.GetConnection())
            using(SqlCommand cmd = new SqlCommand(select, conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_departmentid.DataSource = dt;
                cb_departmentid.DisplayMember = "department_name";
                cb_departmentid.ValueMember = "id";
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tb_coursename.Text))
            {
                MessageBox.Show("Please enter the Course Name.");
                tb_coursename.Focus();
                return;
            }
            if(string.IsNullOrEmpty(tb_gradescaleid.Text))
            {
                MessageBox.Show("Please enter the Grade Scale.");
                tb_gradescaleid.Focus();
                return;
            }
            try
            {
                string insert = @"Insert Into courses (department_id, course_name, grade_scale_id,created_by) Values (@department_id, @course_name, @grade_scale_id, @created_by)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                    cmd.Parameters.AddWithValue("@course_name", tb_coursename.Text);
                    cmd.Parameters.AddWithValue("@grade_scale_id", tb_gradescaleid.Text);
                    cmd.Parameters.AddWithValue("@created_by", Session.LoginUserId);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Course added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }
                tb_coursename.Clear();
                tb_gradescaleid.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error" + ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }

        private void cb_departmentid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tb_coursename_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tb_gradescaleid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
