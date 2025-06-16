using student_scoringV2.Classes;
using student_scoringV2.ConnectionDB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddCourse : Form
    {
        private int _currentCourseId = -1;
        private bool _isEditMode = false;

        public AddCourse()
        {
            InitializeComponent();
            LoadDepartments();
            SetFormState();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            _isEditMode = false;
            _currentCourseId = -1;
            //SetFormState();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_coursename.Text))
            {
                MessageBox.Show("Course name required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_gradescaleid.Text))
            {
                MessageBox.Show("Grade scale ID required.");
                return false;
            }

            if (cb_departmentid.SelectedValue == null)
            {
                MessageBox.Show("Department required.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_coursename.Clear();
            tb_gradescaleid.Clear();
            cb_departmentid.SelectedIndex = -1;
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_coursename.ReadOnly = !_isEditMode;
            tb_gradescaleid.ReadOnly = !_isEditMode;
            cb_departmentid.Enabled = _isEditMode;

            btn_add.Enabled = !_isEditMode;
            btn_search.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_cancel.Visible = _isEditMode;
            btn_delete.Enabled = !_isEditMode && _currentCourseId > 0;
        }

        private void LoadCourseById(int courseId)
        {
            try
            {
                string query = @"SELECT * FROM courses WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", courseId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_coursename.Text = reader["course_name"].ToString();
                            tb_gradescaleid.Text = reader["grade_scale_id"].ToString();
                            cb_departmentid.SelectedValue = reader["department_id"];
                        }
                        else
                        {
                            MessageBox.Show("Course not found.");
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading course: " + ex.Message);
            }
        }

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

                    cb_departmentid.DataSource = dt;
                    cb_departmentid.DisplayMember = "department_name";
                    cb_departmentid.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentCourseId = -1;
            _isEditMode = true;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Mainboard().Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("Please enter Course ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int courseId))
            {
                MessageBox.Show("Invalid Course ID.");
                return;
            }

            _currentCourseId = courseId;
            LoadCourseById(courseId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
                {
                    MessageBox.Show("Please enter or search for a valid Course ID first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentCourseId))
                {
                    MessageBox.Show("Invalid Course ID.");
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
                    if (_currentCourseId > 0)
                    {
                        // UPDATE existing course
                        string update = @"UPDATE courses SET department_id = @department_id, 
                                          course_name = @course_name, grade_scale_id = @grade_scale_id 
                                          WHERE id = @id";
                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                            cmd.Parameters.AddWithValue("@course_name", tb_coursename.Text);
                            cmd.Parameters.AddWithValue("@grade_scale_id", tb_gradescaleid.Text);
                            cmd.Parameters.AddWithValue("@id", _currentCourseId);

                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show(rows > 0 ? "Course updated successfully!" : "Update failed.");
                        }
                    }
                    else
                    {
                        // INSERT new course
                        string insert = @"INSERT INTO courses (department_id, course_name, grade_scale_id, created_by) 
                                      VALUES (@department_id, @course_name, @grade_scale_id, @created_by);
                                      SELECT SCOPE_IDENTITY();";
                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(insert, conn))
                        {
                            cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                            cmd.Parameters.AddWithValue("@course_name", tb_coursename.Text);
                            cmd.Parameters.AddWithValue("@grade_scale_id", tb_gradescaleid.Text);
                            cmd.Parameters.AddWithValue("@created_by", Session.LoginUserId);

                            conn.Open();
                            _currentCourseId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentCourseId.ToString();
                            MessageBox.Show("Course added successfully!");
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving course: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;

            if (_currentCourseId > 0)
                LoadCourseById(_currentCourseId);
            else
                ClearForm();

            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid Course ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentCourseId))
            {
                MessageBox.Show("Invalid Course ID.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM courses WHERE id = @id";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentCourseId);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course deleted successfully.");
                            _currentCourseId = -1;
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("No course was deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting course: " + ex.Message);
                }
            }
        }

        private void AddCourse_Load_1(object sender, EventArgs e)
        {

        }
    }
}