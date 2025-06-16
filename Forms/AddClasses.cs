using student_scoringV2.ConnectionDB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddClasses : Form
    {
        private int _currentClassId = -1;
        private bool _isEditMode = false;

        public AddClasses()
        {
            InitializeComponent();
            SetFormState();
        }

        private void AddClasses_Load(object sender, EventArgs e)
        {
            LoadDataTeacher();
        }

        private void LoadDataTeacher()
        {
            string sql = "SELECT id, first_name + ' ' + last_name AS full_name FROM teachers";
            using (SqlConnection conn = Connectiondb.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cb_teacher.DataSource = dt;
                cb_teacher.DisplayMember = "full_name";
                cb_teacher.ValueMember = "id";
                cb_teacher.SelectedIndex = -1;
            }
        }

        private bool ValidateInputs()
        {
            if (cb_teacher.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Teacher.");
                cb_teacher.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_classname.Text))
            {
                MessageBox.Show("Class name is required.");
                tb_classname.Focus();
                return false;
            }

            if (!int.TryParse(tb_semester.Text, out _))
            {
                MessageBox.Show("Semester must be a number.");
                tb_semester.Focus();
                return false;
            }

            if (!int.TryParse(tb_academicyear.Text, out _))
            {
                MessageBox.Show("Academic Year must be a number.");
                tb_academicyear.Focus();
                return false;
            }

            return true;
        }

        private void LoadClassById(int classId)
        {
            try
            {
                string query = "SELECT * FROM classes WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", classId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            cb_teacher.SelectedValue = reader["teacher_id"];
                            tb_classname.Text = reader["class_name"].ToString();
                            tb_academicyear.Text = reader["academic_year"].ToString();
                            tb_semester.Text = reader["semesters"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Class not found.");
                            _currentClassId = -1;
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading class: " + ex.Message);
            }
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            cb_teacher.Enabled = _isEditMode;
            tb_classname.ReadOnly = !_isEditMode;
            tb_semester.ReadOnly = !_isEditMode;
            tb_academicyear.ReadOnly = !_isEditMode;
            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentClassId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            cb_teacher.SelectedIndex = -1;
            tb_classname.Clear();
            tb_academicyear.Clear();
            tb_semester.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentClassId = -1;
            _isEditMode = true;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
                {
                    MessageBox.Show("Please enter or search for a valid Class ID first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentClassId))
                {
                    MessageBox.Show("Invalid Class ID.");
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
                    if (_currentClassId > 0)
                    {
                        // Update
                        string query = @"UPDATE classes 
                                         SET teacher_id = @teacher_id, 
                                             class_name = @class_name, 
                                             academic_year = @academic_year, 
                                             semesters = @semesters 
                                         WHERE id = @id";

                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@teacher_id", cb_teacher.SelectedValue);
                            cmd.Parameters.AddWithValue("@class_name", tb_classname.Text);
                            cmd.Parameters.AddWithValue("@academic_year", int.Parse(tb_academicyear.Text));
                            cmd.Parameters.AddWithValue("@semesters", int.Parse(tb_semester.Text));
                            cmd.Parameters.AddWithValue("@id", _currentClassId);

                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                                MessageBox.Show("Class updated successfully!");
                        }
                    }
                    else
                    {
                        // Insert
                        string query = @"INSERT INTO classes (teacher_id, class_name, academic_year, semesters)
                                         VALUES (@teacher_id, @class_name, @academic_year, @semesters);
                                         SELECT SCOPE_IDENTITY();";

                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@teacher_id", cb_teacher.SelectedValue);
                            cmd.Parameters.AddWithValue("@class_name", tb_classname.Text);
                            cmd.Parameters.AddWithValue("@academic_year", int.Parse(tb_academicyear.Text));
                            cmd.Parameters.AddWithValue("@semesters", int.Parse(tb_semester.Text));

                            conn.Open();
                            _currentClassId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentClassId.ToString();
                            MessageBox.Show("Class added successfully!");
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving class: " + ex.Message);
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("Please enter Class ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int classId))
            {
                MessageBox.Show("Invalid Class ID.");
                return;
            }

            _currentClassId = classId;
            LoadClassById(classId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid Class ID first.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentClassId))
            {
                MessageBox.Show("Invalid Class ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM classes WHERE id = @id";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentClassId);
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Class deleted successfully.");
                            _currentClassId = -1;
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting class: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentClassId > 0)
                LoadClassById(_currentClassId);
            else
                ClearForm();

            SetFormState();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Mainboard().Show();
        }
    }
}
