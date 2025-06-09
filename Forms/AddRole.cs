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
    public partial class AddRole : Form
    {
        private int _currentRoleId = -1;
        private bool _isEditMode = false;
        public AddRole()
        {
            InitializeComponent();
            SetFormState();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_rolename.Text))
            {
                MessageBox.Show("Role name is required.");
                tb_rolename.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_code.Text))
            {
                MessageBox.Show("Code is required.");
                tb_code.Focus();
                return false;
            }

            return true;
        }

        private void LoadRoleById(int roleId)
        {
            try
            {
                string query = "SELECT * FROM roles WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", roleId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_id.Text = reader["id"].ToString();
                            tb_rolename.Text = reader["role_name"].ToString();
                            tb_code.Text = reader["code"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Role not found.");
                            _currentRoleId = -1;
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading role: " + ex.Message);
            }
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_rolename.ReadOnly = !_isEditMode;
            tb_code.ReadOnly = !_isEditMode;

            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentRoleId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_rolename.Clear();
            tb_code.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            _currentRoleId = -1;
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

        private void AddRole_Load(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
                {
                    MessageBox.Show("Please enter or search for a valid Role ID first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentRoleId))
                {
                    MessageBox.Show("Invalid Role ID.");
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
                    if (_currentRoleId > 0)
                    {
                        string query = @"UPDATE roles SET role_name = @role_name, code = @code WHERE id = @id";
                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@role_name", tb_rolename.Text);
                            cmd.Parameters.AddWithValue("@code", tb_code.Text);
                            cmd.Parameters.AddWithValue("@id", _currentRoleId);

                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                                MessageBox.Show("Role updated successfully!");
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO roles (role_name, code) VALUES (@role_name, @code);
                                         SELECT SCOPE_IDENTITY();";

                        using (SqlConnection conn = Connectiondb.GetConnection())
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@role_name", tb_rolename.Text);
                            cmd.Parameters.AddWithValue("@code", tb_code.Text);

                            conn.Open();
                            _currentRoleId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentRoleId.ToString();
                            MessageBox.Show("Role added successfully!");
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving role: " + ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid Role ID first.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentRoleId))
            {
                MessageBox.Show("Invalid Role ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM roles WHERE id = @id";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentRoleId);
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Role deleted successfully.");
                            _currentRoleId = -1;
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting role: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentRoleId > 0)
                LoadRoleById(_currentRoleId);
            else
                ClearForm();

            SetFormState();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("Please enter Role ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int roleId))
            {
                MessageBox.Show("Invalid Role ID.");
                return;
            }

            _currentRoleId = roleId;
            LoadRoleById(roleId);
            _isEditMode = false;
            SetFormState();
        }
    }
}
