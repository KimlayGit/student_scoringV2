using student_scoringV2.ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        private void LoadDataStudent()
        {
            string select = "Select id, first_name + ' ' + last_name As Full_Name From students";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(select, conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cb_studentname.DataSource = dt;
                cb_studentname.DisplayMember = "Full_Name"; // Display the full name
                cb_studentname.ValueMember = "id"; // Use the student ID as the value
            }
        }

        private void LoadDataCourse()
        {
            string select = "Select id, course_name From courses";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(select, conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cb_coursename.DataSource = dt;
                cb_coursename.DisplayMember = "course_name";
                cb_coursename.ValueMember = "id";
            }
        }

        private void LoadDataClass()
        {
            string select = "Select id, class_name From classes";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(select, conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cb_classnamae.DataSource = dt;
                cb_classnamae.DisplayMember = "class_name";
                cb_classnamae.ValueMember = "id";
            }
        }

        private void LoadDataRecordBy()
        {
            string select = "Select id, first_name + ' ' + last_name As Full_Name From teachers";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(select, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cb_recordby.DataSource = dt;
                cb_recordby.DisplayMember = "Full_Name"; // Display the full name
                cb_recordby.ValueMember = "id"; // Use the teacher ID as the value
            }
        }

        private void CalculatePercentageAndGrade()
        {
            if (double.TryParse(tb_scorevalue.Text, out double scoreValue) &&
                double.TryParse(tb_maximumscore.Text, out double maximumScore))
            {
                if (maximumScore == 0)
                {
                    MessageBox.Show("Maximum score cannot be zero.");
                    return;
                }

                double percentage = (scoreValue / maximumScore) * 100;
                tb_percentage.Text = percentage.ToString("0.00"); // Format to 2 decimal places

                // Auto-determine grade letter (example logic)
                string gradeLetter = "";
                if (percentage >= 90) gradeLetter = "A";
                else if (percentage >= 80) gradeLetter = "B";
                else if (percentage >= 70) gradeLetter = "C";
                else if (percentage >= 60) gradeLetter = "D";
                else gradeLetter = "F";

                tb_gradeletter.Text = gradeLetter;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {

            // Validation checks (should be at the top level, not nested)
            if (string.IsNullOrEmpty(tb_maximumscore.Text))
            {
                MessageBox.Show("Please enter the Maximum Score.");
                tb_maximumscore.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tb_scorevalue.Text))
            {
                MessageBox.Show("Please enter the Score Value.");
                tb_scorevalue.Focus();
                return;
            }

            // Calculate percentage if not already done
            CalculatePercentageAndGrade();

            try
            {
                string sql = @"INSERT INTO scores (student_id, course_id, class_id, recorded_by, 
                       score_value, maximum_score, percentage, grade_letter) 
                      VALUES 
                      (@student_id, @course_id, @class_id, @recorded_by, 
                       @score_value, @maximum_score, @percentage, @grade_letter)";

                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@student_id", cb_studentname.SelectedValue);
                    cmd.Parameters.AddWithValue("@course_id", cb_coursename.SelectedValue);
                    cmd.Parameters.AddWithValue("@class_id", cb_classnamae.SelectedValue);
                    cmd.Parameters.AddWithValue("@recorded_by", cb_recordby.SelectedValue);
                    cmd.Parameters.AddWithValue("@score_value", double.Parse(tb_scorevalue.Text));
                    cmd.Parameters.AddWithValue("@maximum_score", double.Parse(tb_maximumscore.Text));
                    cmd.Parameters.AddWithValue("@percentage", double.Parse(tb_percentage.Text));
                    cmd.Parameters.AddWithValue("@grade_letter", tb_gradeletter.Text);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Score added successfully.");
                        // Clear fields after successful insert
                        tb_scorevalue.Clear();
                        tb_maximumscore.Clear();
                        tb_percentage.Clear();
                        tb_gradeletter.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Insert failed. No rows affected.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
  


            private void tb_scorevalue_TextChanged(object sender, EventArgs e)
            {
                CalculatePercentageAndGrade();
            }

            private void AddScore_Load(object sender, EventArgs e)
            {
                LoadDataClass();
                LoadDataCourse();
                LoadDataStudent();
                LoadDataRecordBy();
            }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }

        private void tb_maximumscore_TextChanged(object sender, EventArgs e)
        {
            CalculatePercentageAndGrade();
        }
    }
}
