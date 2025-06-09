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

        private int _currentStudentId = -1;
        private bool _isEditMode = false;
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

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_firstname.ReadOnly = !_isEditMode;
            tb_lastname.ReadOnly = !_isEditMode;
            tb_email.ReadOnly = !_isEditMode;
            tb_phonenumber.ReadOnly = !_isEditMode;
            tb_address.ReadOnly = !_isEditMode;
            cb_gender.Enabled = _isEditMode;
            cb_class.Enabled = _isEditMode;
            dtp_dob.Enabled = _isEditMode;
            dtp_enrollment.Enabled = _isEditMode;

            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentStudentId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_firstname.Clear();
            tb_lastname.Clear();
            tb_email.Clear();
            tb_phonenumber.Clear();
            tb_address.Clear();
            cb_gender.SelectedIndex = -1;
            cb_class.SelectedIndex = -1;
            dtp_dob.Value = DateTime.Now;
            dtp_enrollment.Value = DateTime.Now;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_firstname.Text)) { MessageBox.Show("First name required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_lastname.Text)) { MessageBox.Show("Last name required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_email.Text)) { MessageBox.Show("Email required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_phonenumber.Text)) { MessageBox.Show("Phone number required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_address.Text)) { MessageBox.Show("Address required."); return false; }
            if (cb_gender.SelectedIndex == -1) { MessageBox.Show("Gender required."); return false; }
            if (cb_class.SelectedIndex == -1) { MessageBox.Show("Class required."); return false; }

            return true;
        }

        private void LoadStudentById(int id)
        {
            try
            {
                string sql = "SELECT * FROM students WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_firstname.Text = reader["first_name"].ToString();
                            tb_lastname.Text = reader["last_name"].ToString();
                            tb_email.Text = reader["email"].ToString();
                            tb_phonenumber.Text = reader["phone_number"].ToString();
                            tb_address.Text = reader["address"].ToString();
                            cb_gender.SelectedItem = reader["gender"].ToString();
                            dtp_dob.Value = Convert.ToDateTime(reader["dob"]);
                            dtp_enrollment.Value = Convert.ToDateTime(reader["enrollment_date"]);
                            cb_class.SelectedValue = reader["class_id"];
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student: " + ex.Message);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {

            _currentStudentId = -1;
            _isEditMode = true;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
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
            SetFormState();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_id.Text, out _currentStudentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            LoadStudentById(_currentStudentId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("Please search for a student first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentStudentId))
                {
                    MessageBox.Show("Invalid Student ID.");
                    return;
                }

                _isEditMode = true;
                SetFormState();
            }
            else
            {
                if (!ValidateInputs()) return;

                try
                {
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    {
                        conn.Open();

                        if (_currentStudentId > 0)
                        {
                            string update = @"UPDATE students 
                                              SET class_id = @class_id, first_name = @first_name, last_name = @last_name,
                                                  dob = @dob, gender = @gender, phone_number = @phone_number,
                                                  email = @email, address = @address, enrollment_date = @enrollment_date
                                              WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@class_id", cb_class.SelectedValue);
                                cmd.Parameters.AddWithValue("@first_name", tb_firstname.Text);
                                cmd.Parameters.AddWithValue("@last_name", tb_lastname.Text);
                                cmd.Parameters.AddWithValue("@dob", dtp_dob.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@gender", cb_gender.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@phone_number", tb_phonenumber.Text);
                                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                                cmd.Parameters.AddWithValue("@address", tb_address.Text);
                                cmd.Parameters.AddWithValue("@enrollment_date", dtp_enrollment.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@id", _currentStudentId);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Student updated successfully!");
                            }
                        }
                        else
                        {
                            string insert = @"INSERT INTO students 
                                              (class_id, first_name, last_name, dob, gender, phone_number, email, address, enrollment_date)
                                              VALUES 
                                              (@class_id, @first_name, @last_name, @dob, @gender, @phone_number, @email, @address, @enrollment_date);
                                              SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@class_id", cb_class.SelectedValue);
                                cmd.Parameters.AddWithValue("@first_name", tb_firstname.Text);
                                cmd.Parameters.AddWithValue("@last_name", tb_lastname.Text);
                                cmd.Parameters.AddWithValue("@dob", dtp_dob.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@gender", cb_gender.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@phone_number", tb_phonenumber.Text);
                                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                                cmd.Parameters.AddWithValue("@address", tb_address.Text);
                                cmd.Parameters.AddWithValue("@enrollment_date", dtp_enrollment.Value.ToString("yyyy-MM-dd"));

                                _currentStudentId = Convert.ToInt32(cmd.ExecuteScalar());
                                tb_id.Text = _currentStudentId.ToString();

                                MessageBox.Show("Student added successfully!");
                            }
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_id.Text, out _currentStudentId))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentStudentId);
                        conn.Open();

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Student deleted.");
                            ClearForm();
                            _currentStudentId = -1;
                            SetFormState();
                        }
                        else
                        {
                            MessageBox.Show("No student deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
                }
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentStudentId > 0)
                LoadStudentById(_currentStudentId);
            else
                ClearForm();

            SetFormState();
        }
    }
}
