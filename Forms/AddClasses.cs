using student_scoringV2.ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddClasses : Form
    {
        public AddClasses()
        {
            InitializeComponent();
        }

        private void LoadDataTeacher()
        {
            string sql = "SELECT id, first_name + ' ' + last_name AS full_name FROM teachers"; // Adjusted to use full name
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cb_teacher.DataSource = dt;
                cb_teacher.DisplayMember = "full_name"; // Display the full name
                cb_teacher.ValueMember = "id"; // Use the teacher ID as the value
                cb_teacher.SelectedIndex = -1; // No selection by default
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_classname.Text))
            {
                MessageBox.Show("Please enter the Class Name.");
                tb_classname.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_semester.Text))
            {
                MessageBox.Show("Please enter the Semester.");
                tb_semester.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_academicyear.Text))
            {
                MessageBox.Show("Please enter the Academic Year.");
                tb_academicyear.Focus();
                return;
            }

            try
            {
                string insert = @"
            INSERT INTO classes 
                (teacher_id, class_name, academic_year, semesters) 
            VALUES 
                (@teacher_id, @class_name, @academic_year, @semesters)";

                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", cb_teacher.SelectedValue);
                    cmd.Parameters.AddWithValue("@class_name", tb_classname.Text);
                    cmd.Parameters.AddWithValue("@academic_year", int.Parse(tb_academicyear.Text));
                    cmd.Parameters.AddWithValue("@semesters", int.Parse(tb_semester.Text));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Class added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                //tb_teacherid.Clear();
                tb_classname.Clear();
                tb_academicyear.Clear();
                tb_semester.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void AddClasses_Load(object sender, EventArgs e)
        {
            LoadDataTeacher();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }
    }
}
