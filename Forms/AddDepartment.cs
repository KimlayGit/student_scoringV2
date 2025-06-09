using student_scoringV2.ConnectionDB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddDepartment : Form
    {
        private int _currentDepartmentId = -1;
        private bool _isEditMode = false;

        public AddDepartment()
        {
            InitializeComponent();
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            LoadTeacher();
            SetFormState();
        }

        private void LoadTeacher()
        {
            try
            {
                string query = "SELECT id, first_name + ' ' + last_name AS full_name FROM teachers";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    cb_headofdepartment.DataSource = dt;
                    cb_headofdepartment.DisplayMember = "full_name";
                    cb_headofdepartment.ValueMember = "id";
                    cb_headofdepartment.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers: " + ex.Message);
            }
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = true;
            tb_departmentname.ReadOnly = !_isEditMode;
            tb_code.ReadOnly = !_isEditMode;
            cb_headofdepartment.Enabled = _isEditMode;

            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentDepartmentId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_departmentname.Clear();
            tb_code.Clear();
            cb_headofdepartment.SelectedIndex = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_departmentname.Text))
            {
                MessageBox.Show("Department Name is required.");
                tb_departmentname.Focus();
                return false;
            }

            return true;
        }

        private void LoadDepartmentById(int id)
        {
            try
            {
                string query = "SELECT * FROM departments WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_departmentname.Text = reader["department_name"].ToString();
                            tb_code.Text = reader["code"].ToString();
                            cb_headofdepartment.SelectedValue = reader["head_of_department"];
                        }
                        else
                        {
                            MessageBox.Show("Department not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading department: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentDepartmentId = -1;
            _isEditMode = true;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("Please search for a department first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentDepartmentId))
                {
                    MessageBox.Show("Invalid Department ID.");
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
                    object headValue = cb_headofdepartment.SelectedValue ?? (object)DBNull.Value;

                    using (SqlConnection conn = Connectiondb.GetConnection())
                    {
                        conn.Open();

                        if (_currentDepartmentId > 0)
                        {
                            string update = @"UPDATE departments 
                                              SET head_of_department = @head_of_department, 
                                                  department_name = @department_name, 
                                                  code = @code 
                                              WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@head_of_department", headValue);
                                cmd.Parameters.AddWithValue("@department_name", tb_departmentname.Text);
                                cmd.Parameters.AddWithValue("@code", tb_code.Text);
                                cmd.Parameters.AddWithValue("@id", _currentDepartmentId);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Department updated successfully!");
                            }
                        }
                        else
                        {
                            string insert = @"INSERT INTO departments (head_of_department, department_name, code) 
                                              VALUES (@head_of_department, @department_name, @code);
                                              SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@head_of_department", headValue);
                                cmd.Parameters.AddWithValue("@department_name", tb_departmentname.Text);
                                cmd.Parameters.AddWithValue("@code", tb_code.Text);

                                _currentDepartmentId = Convert.ToInt32(cmd.ExecuteScalar());
                                tb_id.Text = _currentDepartmentId.ToString();

                                MessageBox.Show("Department added successfully!");
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_id.Text, out _currentDepartmentId))
            {
                MessageBox.Show("Please enter a valid numeric Department ID.");
                return;
            }

            LoadDepartmentById(_currentDepartmentId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_id.Text, out _currentDepartmentId))
            {
                MessageBox.Show("Please enter a valid numeric Department ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this department?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM departments WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentDepartmentId);
                        conn.Open();

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Department deleted.");
                            ClearForm();
                            _currentDepartmentId = -1;
                            SetFormState();
                        }
                        else
                        {
                            MessageBox.Show("No department deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting department: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentDepartmentId > 0)
                LoadDepartmentById(_currentDepartmentId);
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
