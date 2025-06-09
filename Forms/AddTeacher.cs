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

namespace student_scoringV2.Forms
{
    public partial class AddTeacher : Form
    {
        private int _currentTeacherId = -1;
        private bool _isEditMode = false;

        public AddTeacher()
        {
            InitializeComponent();
            LoadDepartments(); // Load departments when form initializes
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_fname.Text)) { MessageBox.Show("First name required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_lname.Text)) { MessageBox.Show("Last name required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_address.Text)) { MessageBox.Show("Address required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_pnumber.Text)) { MessageBox.Show("Phone number required."); return false; }
            if (string.IsNullOrWhiteSpace(tb_email.Text)) { MessageBox.Show("Email required."); return false; }
            if (cb_departmentid.SelectedValue == null) { MessageBox.Show("Department required."); return false; }
            return true;
        }


        private void ClearForm()
        {
            tb_id.Clear();
            tb_fname.Clear();
            tb_lname.Clear();
            tb_address.Clear();
            tb_pnumber.Clear();
            tb_email.Clear();
            cb_departmentid.SelectedIndex = -1;
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_fname.ReadOnly = !_isEditMode;
            tb_lname.ReadOnly = !_isEditMode;
            tb_address.ReadOnly = !_isEditMode;
            tb_pnumber.ReadOnly = !_isEditMode;
            tb_email.ReadOnly = !_isEditMode;
            cb_departmentid.Enabled = _isEditMode;

            btn_add.Enabled = !_isEditMode;
            btn_search.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_cancel.Visible = _isEditMode;
            btn_delete.Enabled = !_isEditMode && _currentTeacherId > 0;

        }


        private void LoadTeacherById(int teacherId)
        {
            try
            {
                string query = @"SELECT * FROM teachers WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", teacherId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_fname.Text = reader["first_name"].ToString();
                            tb_lname.Text = reader["last_name"].ToString();
                            tb_address.Text = reader["address"].ToString();
                            tb_pnumber.Text = reader["phone_number"].ToString();
                            tb_email.Text = reader["email"].ToString();
                            cb_departmentid.SelectedValue = reader["department_id"];
                        }
                        else
                        {
                            MessageBox.Show("Teacher not found.");
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teacher: " + ex.Message);
            }
        }


        // Load departments into combobox
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

                    // Set up the ComboBox
                    cb_departmentid.DataSource = dt;
                    cb_departmentid.DisplayMember = "department_name"; // What to show to the user
                    cb_departmentid.ValueMember = "id";                // What to use as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentTeacherId = -1;
            _isEditMode = true;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tb_id.Text))
    {
                MessageBox.Show("Please enter Teacher ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int teacherId))
            {
                MessageBox.Show("Invalid Teacher ID.");
                return;
            }

            _currentTeacherId = teacherId;
            LoadTeacherById(teacherId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
                {
                    MessageBox.Show("Please enter or search for a valid Teacher ID first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentTeacherId))
                {
                    MessageBox.Show("Invalid Teacher ID.");
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
                    if (_currentTeacherId > 0)
                    {
                        // UPDATE existing teacher
                        string update = @"UPDATE teachers SET department_id = @department_id, first_name = @first_name,
                                  last_name = @last_name, address = @address, phone_number = @phone_number,
                                  email = @email WHERE id = @id";
                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                            cmd.Parameters.AddWithValue("@first_name", tb_fname.Text);
                            cmd.Parameters.AddWithValue("@last_name", tb_lname.Text);
                            cmd.Parameters.AddWithValue("@address", tb_address.Text);
                            cmd.Parameters.AddWithValue("@phone_number", tb_pnumber.Text);
                            cmd.Parameters.AddWithValue("@email", tb_email.Text);
                            cmd.Parameters.AddWithValue("@id", _currentTeacherId);

                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show(rows > 0 ? "Teacher updated successfully!" : "Update failed.");
                        }
                    }
                    else
                    {
                        // INSERT new teacher
                        string insert = @"INSERT INTO teachers (department_id, first_name, last_name, address, 
                                  phone_number, email, created_by) 
                                  VALUES (@department_id, @first_name, @last_name, @address, 
                                  @phone_number, @email, @created_by);
                                  SELECT SCOPE_IDENTITY();";
                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(insert, conn))
                        {
                            cmd.Parameters.AddWithValue("@department_id", cb_departmentid.SelectedValue);
                            cmd.Parameters.AddWithValue("@first_name", tb_fname.Text);
                            cmd.Parameters.AddWithValue("@last_name", tb_lname.Text);
                            cmd.Parameters.AddWithValue("@address", tb_address.Text);
                            cmd.Parameters.AddWithValue("@phone_number", tb_pnumber.Text);
                            cmd.Parameters.AddWithValue("@email", tb_email.Text);
                            cmd.Parameters.AddWithValue("@created_by", Session.LoginUserId);

                            conn.Open();
                            _currentTeacherId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentTeacherId.ToString();
                            MessageBox.Show("Teacher added successfully!");
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving teacher: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;

            if (_currentTeacherId > 0)
                LoadTeacherById(_currentTeacherId);
            else
                ClearForm();

            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid Teacher ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentTeacherId))
            {
                MessageBox.Show("Invalid Teacher ID.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM teachers WHERE id = @id";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentTeacherId);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Teacher deleted successfully.");
                            _currentTeacherId = -1;
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("No teacher was deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting teacher: " + ex.Message);
                }
            }
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {

        }
    }
}