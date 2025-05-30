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
    public partial class GradeScale : Form
    {
        public GradeScale()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(tb_id.Text))
            //{
            //    MessageBox.Show("Please enter the ID.");
            //    tb_gradeletter.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(tb_scalename.Text))
            {
                MessageBox.Show("Please enter the Grade Letter.");
                tb_scalename.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_min.Text))
            {
                MessageBox.Show("Please enter the Minimum Score.");
                tb_min.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_max.Text))
            {
                MessageBox.Show("Please enter the Maximum Score.");
                tb_max.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_gpa.Text))
            {
                MessageBox.Show("Please enter the Description.");
                tb_gpa.Focus();
                return;
            }
            try
            {
                string insert = @"INSERT INTO grade_scale (grade_letter, scale_name, min_percentage, max_percentage, grade_points) 
                                  VALUES (@grade_letter, @scale_name, @min_score, @max_score, @gpa)";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    //cmd.Parameters.AddWithValue("@id", tb_id.Text);
                    cmd.Parameters.AddWithValue("@grade_letter", tb_gradeletter.Text);
                    cmd.Parameters.AddWithValue("@scale_name", tb_scalename.Text);
                    cmd.Parameters.AddWithValue("@min_score", int.Parse(tb_min.Text));
                    cmd.Parameters.AddWithValue("@max_score", int.Parse(tb_max.Text));
                    cmd.Parameters.AddWithValue("@gpa", double.Parse(tb_gpa.Text));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Grade Scale added successfully.");
                    else
                        MessageBox.Show("Insert failed. No rows affected.");
                }

                // Clear fields
                tb_id.Clear();
                tb_gradeletter.Clear();
                tb_scalename.Clear();
                tb_min.Clear();
                tb_max.Clear();
                tb_gpa.Clear();
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
