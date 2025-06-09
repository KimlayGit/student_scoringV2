using student_scoringV2.ConnectionDB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddUser : Form
    {
        private int _currentUserId = -1;
        private bool _isEditMode = false;

        public AddUser()
        {
            InitializeComponent();
            LoadRoles();
            SetFormState();
        }

        private void LoadRoles()
        {
            try
            {
                string query = "SELECT id, role_name FROM roles ORDER BY role_name";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    cb_role.DataSource = dt;
                    cb_role.DisplayMember = "role_name";
                    cb_role.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
        }

        private void LoadUserById(int userId)
        {
            try
            {
                string query = @"SELECT u.*, r.role_name 
                                FROM users u
                                JOIN roles r ON u.role_id = r.id
                                WHERE u.id = @UserId";

                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_email.Text = reader["email"].ToString();
                            tb_username.Text = reader["username"].ToString();
                            tb_password.Text = string.Empty; // Don't show actual password

                            // Set the role in combobox
                            foreach (DataRowView item in cb_role.Items)
                            {
                                if (Convert.ToInt32(item["id"]) == Convert.ToInt32(reader["role_id"]))
                                {
                                    cb_role.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainboard mainboard = new Mainboard();
            mainboard.Show();
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_email.Text))
            {
                MessageBox.Show("Email is required.");
                tb_email.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_username.Text))
            {
                MessageBox.Show("Username is required.");
                tb_username.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_password.Text))
            {
                MessageBox.Show("Password is required.");
                tb_password.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_email.Clear();
            tb_username.Clear();
            tb_password.Clear();
            cb_role.SelectedIndex = 0;
        }

        private void SetFormState()
        {
            // Set control enable states
            tb_id.ReadOnly = _isEditMode && _currentUserId > 0;
            tb_email.ReadOnly = !_isEditMode;
            tb_username.ReadOnly = !_isEditMode;
            tb_password.ReadOnly = !_isEditMode;
            cb_role.Enabled = _isEditMode;

            // Set button states
            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentUserId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("Please enter a User ID to search.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int userId))
            {
                MessageBox.Show("Please enter a valid numeric User ID.");
                return;
            }

            _currentUserId = userId;
            LoadUserById(userId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentUserId > 0)
            {
                LoadUserById(_currentUserId);
            }
            else
            {
                ClearForm();
            }
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                // Edit mode - validate we have a user to edit
                if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
                {
                    MessageBox.Show("Please enter or search for a valid User ID first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentUserId))
                {
                    MessageBox.Show("Please enter a valid numeric User ID.");
                    return;
                }

                _isEditMode = true;
                SetFormState();
            }
            else
            {
                // Save mode - validate inputs
                if (!ValidateInputs()) return;

                try
                {
                    if (_currentUserId > 0)
                    {
                        // Update existing user
                        string query = @"UPDATE users SET 
                                        role_id = @role_id, 
                                        email = @email, 
                                        username = @username, 
                                        password = @password
                                        WHERE id = @UserId";

                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@role_id", cb_role.SelectedValue);
                            cmd.Parameters.AddWithValue("@email", tb_email.Text);
                            cmd.Parameters.AddWithValue("@username", tb_username.Text);
                            cmd.Parameters.AddWithValue("@password", tb_password.Text);
                            cmd.Parameters.AddWithValue("@UserId", _currentUserId);

                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User updated successfully!");
                            }
                        }
                    }
                    else
                    {
                        // Insert new user
                        string query = @"INSERT INTO users 
                                        (role_id, email, username, password) 
                                        VALUES (@role_id, @email, @username, @password);
                                        SELECT SCOPE_IDENTITY();";

                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@role_id", cb_role.SelectedValue);
                            cmd.Parameters.AddWithValue("@email", tb_email.Text);
                            cmd.Parameters.AddWithValue("@username", tb_username.Text);
                            cmd.Parameters.AddWithValue("@password", tb_password.Text);

                            conn.Open();
                            _currentUserId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentUserId.ToString();
                            MessageBox.Show("User added successfully with ID: " + _currentUserId);
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving user: " + ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid User ID first.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentUserId))
            {
                MessageBox.Show("Please enter a valid numeric User ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM users WHERE id = @UserId";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", _currentUserId);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully!");
                            _currentUserId = -1;
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentUserId = -1;
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
    }
}