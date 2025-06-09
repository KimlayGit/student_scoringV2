using student_scoringV2.ConnectionDB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class AddScore : Form
    {
        private int _currentScoreId = -1;
        private bool _isEditMode = false;

        public AddScore()
        {
            InitializeComponent();
        }

        private void AddScore_Load(object sender, EventArgs e)
        {
            LoadDataStudent();
            LoadDataCourse();
            LoadDataClass();
            LoadDataRecordBy();
            SetFormState();
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
                cb_studentname.DisplayMember = "Full_Name";
                cb_studentname.ValueMember = "id";
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
                cb_recordby.DisplayMember = "Full_Name";
                cb_recordby.ValueMember = "id";
            }
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_scorevalue.ReadOnly = !_isEditMode;
            tb_maximumscore.ReadOnly = !_isEditMode;
            cb_studentname.Enabled = _isEditMode;
            cb_classnamae.Enabled = _isEditMode;
            cb_coursename.Enabled = _isEditMode;
            cb_recordby.Enabled = _isEditMode;
            btn_add.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_delete.Enabled = !_isEditMode && _currentScoreId > 0;
            btn_search.Enabled = !_isEditMode;
            btn_cancel.Visible = _isEditMode;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_scorevalue.Clear();
            tb_maximumscore.Clear();
            tb_percentage.Clear();
            tb_gradeletter.Clear();
            cb_studentname.SelectedIndex = -1;
            cb_classnamae.SelectedIndex = -1;
            cb_coursename.SelectedIndex = -1;
            cb_recordby.SelectedIndex = -1;
        }

        private void CalculatePercentageAndGrade()
        {
            if (double.TryParse(tb_scorevalue.Text, out double scoreValue) &&
                double.TryParse(tb_maximumscore.Text, out double maximumScore) && maximumScore != 0)
            {
                double percentage = (scoreValue / maximumScore) * 100;
                tb_percentage.Text = percentage.ToString("0.00");
                tb_gradeletter.Text = percentage >= 90 ? "A" : percentage >= 80 ? "B" :
                                      percentage >= 70 ? "C" : percentage >= 60 ? "D" : "F";
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_scorevalue.Text) || string.IsNullOrWhiteSpace(tb_maximumscore.Text))
            {
                MessageBox.Show("Score and maximum score are required.");
                return false;
            }
            return true;
        }

        private void LoadScoreById(int id)
        {
            try
            {
                string query = "SELECT * FROM scores WHERE id = @id";
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
                            cb_studentname.SelectedValue = reader["student_id"];
                            cb_coursename.SelectedValue = reader["course_id"];
                            cb_classnamae.SelectedValue = reader["class_id"];
                            cb_recordby.SelectedValue = reader["recorded_by"];
                            tb_scorevalue.Text = reader["score_value"].ToString();
                            tb_maximumscore.Text = reader["maximum_score"].ToString();
                            tb_percentage.Text = reader["percentage"].ToString();
                            tb_gradeletter.Text = reader["grade_letter"].ToString();
                        }
                        else MessageBox.Show("Score record not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading score: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _isEditMode = true;
            _currentScoreId = -1;
            ClearForm();
            tb_id.Text = "Auto-generated";
            SetFormState();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                if (!int.TryParse(tb_id.Text, out _currentScoreId))
                {
                    MessageBox.Show("Please search for a score record first.");
                    return;
                }
                _isEditMode = true;
                SetFormState();
            }
            else
            {
                if (!ValidateInputs()) return;
                CalculatePercentageAndGrade();
                try
                {
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd;
                        if (_currentScoreId > 0)
                        {
                            cmd = new SqlCommand("UPDATE scores SET student_id=@student_id, course_id=@course_id, class_id=@class_id, recorded_by=@recorded_by, score_value=@score_value, maximum_score=@maximum_score, percentage=@percentage, grade_letter=@grade_letter WHERE id=@id", conn);
                            cmd.Parameters.AddWithValue("@id", _currentScoreId);
                        }
                        else
                        {
                            cmd = new SqlCommand("INSERT INTO scores (student_id, course_id, class_id, recorded_by, score_value, maximum_score, percentage, grade_letter) VALUES (@student_id, @course_id, @class_id, @recorded_by, @score_value, @maximum_score, @percentage, @grade_letter); SELECT SCOPE_IDENTITY();", conn);
                        }

                        cmd.Parameters.AddWithValue("@student_id", cb_studentname.SelectedValue);
                        cmd.Parameters.AddWithValue("@course_id", cb_coursename.SelectedValue);
                        cmd.Parameters.AddWithValue("@class_id", cb_classnamae.SelectedValue);
                        cmd.Parameters.AddWithValue("@recorded_by", cb_recordby.SelectedValue);
                        cmd.Parameters.AddWithValue("@score_value", double.Parse(tb_scorevalue.Text));
                        cmd.Parameters.AddWithValue("@maximum_score", double.Parse(tb_maximumscore.Text));
                        cmd.Parameters.AddWithValue("@percentage", double.Parse(tb_percentage.Text));
                        cmd.Parameters.AddWithValue("@grade_letter", tb_gradeletter.Text);

                        if (_currentScoreId > 0)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Score updated successfully.");
                        }
                        else
                        {
                            _currentScoreId = Convert.ToInt32(cmd.ExecuteScalar());
                            tb_id.Text = _currentScoreId.ToString();
                            MessageBox.Show("Score added successfully.");
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
            if (!int.TryParse(tb_id.Text, out _currentScoreId))
            {
                MessageBox.Show("Please enter a valid numeric ID.");
                return;
            }
            LoadScoreById(_currentScoreId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_id.Text, out _currentScoreId)) return;
            if (MessageBox.Show("Delete this score?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM scores WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentScoreId);
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Score deleted.");
                            ClearForm();
                            _currentScoreId = -1;
                            SetFormState();
                        }
                        else MessageBox.Show("No record deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting score: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            if (_currentScoreId > 0)
                LoadScoreById(_currentScoreId);
            else
                ClearForm();
            SetFormState();
        }

        private void tb_scorevalue_TextChanged(object sender, EventArgs e) => CalculatePercentageAndGrade();
        private void tb_maximumscore_TextChanged(object sender, EventArgs e) => CalculatePercentageAndGrade();

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Mainboard().Show();
        }
    }
}
