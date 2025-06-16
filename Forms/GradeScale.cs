using student_scoringV2.ConnectionDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class GradeScale : Form
    {
        private int _currentGradeScaleId = -1;
        private bool _isEditMode = false;

        private readonly HashSet<string> _validGradeLetters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F"
        };

        public GradeScale()
        {
            InitializeComponent();
            InitializeGPAFunctionality();
            SetupGradeLetterAutoComplete();
            SetFormState();
        }

        private void SetupGradeLetterAutoComplete()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(new[] { "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F" });
            tb_gradeletter.AutoCompleteCustomSource = source;
            tb_gradeletter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void InitializeGPAFunctionality()
        {
            tb_min.TextChanged += CalculateGPAFromPercentage;
            tb_max.TextChanged += CalculateGPAFromPercentage;

            tb_gradeletter.TextChanged += (sender, e) =>
            {
                if (_isEditMode && !string.IsNullOrEmpty(tb_gradeletter.Text))
                {
                    UpdateScaleNameFromGradeLetter();
                    tb_gpa.Text = CalculateGPA(tb_gradeletter.Text).ToString("0.0");
                }
            };
        }

        private void UpdateScaleNameFromGradeLetter()
        {
            string gradeLetter = tb_gradeletter.Text.Trim().ToUpper();
            if (gradeLetter == "F")
            {
                tb_scalename.Text = "Fail";
            }
            else if (_validGradeLetters.Contains(gradeLetter))
            {
                tb_scalename.Text = "Pass";
            }
            else
            {
                tb_scalename.Text = string.Empty;
            }
        }

        private void CalculateGPAFromPercentage(object sender, EventArgs e)
        {
            if (!_isEditMode) return;

            if (decimal.TryParse(tb_min.Text, out decimal min) &&
                decimal.TryParse(tb_max.Text, out decimal max))
            {
                decimal midpoint = (min + max) / 2;
                double gpa = CalculateGPAFromPercentageRange(midpoint);
                tb_gpa.Text = gpa.ToString("0.0");
                tb_gradeletter.Text = GetGradeLetterFromGPA(gpa);
                UpdateScaleNameFromGradeLetter();
            }
        }

        private double CalculateGPAFromPercentageRange(decimal percentage)
        {
            if (percentage >= 97m) return 4.0;
            if (percentage >= 93m) return 4.0;
            if (percentage >= 90m) return 3.7;
            if (percentage >= 87m) return 3.3;
            if (percentage >= 83m) return 3.0;
            if (percentage >= 80m) return 2.7;
            if (percentage >= 77m) return 2.3;
            if (percentage >= 73m) return 2.0;
            if (percentage >= 70m) return 1.7;
            if (percentage >= 67m) return 1.3;
            if (percentage >= 60m) return 1.0;
            return 0.0;
        }

        private string GetGradeLetterFromGPA(double gpa)
        {
            if (gpa >= 4.0) return "A+";
            if (gpa >= 3.7) return "A";
            if (gpa >= 3.3) return "A-";
            if (gpa >= 3.0) return "B+";
            if (gpa >= 2.7) return "B";
            if (gpa >= 2.3) return "B-";
            if (gpa >= 2.0) return "C+";
            if (gpa >= 1.7) return "C";
            if (gpa >= 1.3) return "C-";
            if (gpa >= 1.0) return "D+";
            return "F";
        }

        private double CalculateGPA(string gradeLetter)
        {
            switch (gradeLetter.ToUpper())
            {
                case "A+": return 4.0;
                case "A": return 4.0;
                case "A-": return 3.7;
                case "B+": return 3.3;
                case "B": return 3.0;
                case "B-": return 2.7;
                case "C+": return 2.3;
                case "C": return 2.0;
                case "C-": return 1.7;
                case "D+": return 1.3;
                case "D": return 1.0;
                case "F": return 0.0;
                default: return 0.0;
            }
        }

        private void GradeScale_Load(object sender, EventArgs e)
        {
            _isEditMode = false;
            _currentGradeScaleId = -1;
            SetFormState();
        }

        private bool ValidateInputs()
        {
            string gradeLetter = tb_gradeletter.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(gradeLetter) || !_validGradeLetters.Contains(gradeLetter))
            {
                MessageBox.Show("Please enter a valid grade letter (A+, A, A-, B+, etc.)");
                tb_gradeletter.Focus();
                return false;
            }

            string expectedDescriptor = gradeLetter == "F" ? "Fail" : "Pass";
            if (tb_scalename.Text != expectedDescriptor)
            {
                MessageBox.Show($"Scale name must be: '{expectedDescriptor}'");
                return false;
            }

            if (!decimal.TryParse(tb_min.Text, out decimal min) || min < 0 || min > 100)
            {
                MessageBox.Show("Please enter a valid minimum percentage (0-100).");
                tb_min.Focus();
                return false;
            }

            if (!decimal.TryParse(tb_max.Text, out decimal max) || max < 0 || max > 100)
            {
                MessageBox.Show("Please enter a valid maximum percentage (0-100).");
                tb_max.Focus();
                return false;
            }

            if (min >= max)
            {
                MessageBox.Show("Minimum percentage must be less than maximum percentage.");
                tb_min.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            tb_id.Clear();
            tb_gradeletter.Clear();
            tb_scalename.Clear();
            tb_min.Clear();
            tb_max.Clear();
            tb_gpa.Clear();
        }

        private void SetFormState()
        {
            tb_id.ReadOnly = _isEditMode;
            tb_gradeletter.ReadOnly = !_isEditMode;
            tb_scalename.ReadOnly = true;
            tb_min.ReadOnly = !_isEditMode;
            tb_max.ReadOnly = !_isEditMode;
            tb_gpa.ReadOnly = true;

            btn_add.Enabled = !_isEditMode;
            btn_search.Enabled = !_isEditMode;
            btn_edit.Text = _isEditMode ? "Save" : "Edit";
            btn_cancel.Visible = _isEditMode;
            btn_delete.Enabled = !_isEditMode && _currentGradeScaleId > 0;
        }

        private void LoadGradeScaleById(int gradeScaleId)
        {
            try
            {
                string query = "SELECT * FROM grade_scale WHERE id = @id";
                using (SqlConnection conn = Connectiondb.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", gradeScaleId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _currentGradeScaleId = gradeScaleId;
                            tb_id.Text = reader["id"].ToString();
                            tb_gradeletter.Text = reader["grade_letter"].ToString();
                            tb_scalename.Text = reader["scale_name"].ToString();
                            tb_min.Text = reader["min_percentage"].ToString();
                            tb_max.Text = reader["max_percentage"].ToString();
                            tb_gpa.Text = reader["grade_points"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Grade scale not found.");
                            ClearForm();
                            _currentGradeScaleId = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grade scale: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            _currentGradeScaleId = -1;
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
                    MessageBox.Show("Please search for a grade scale first.");
                    return;
                }

                if (!int.TryParse(tb_id.Text, out _currentGradeScaleId))
                {
                    MessageBox.Show("Invalid Grade Scale ID.");
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

                        if (_currentGradeScaleId > 0)
                        {
                            string update = @"UPDATE grade_scale 
                                               SET grade_letter = @grade_letter,
                                                   scale_name = @scale_name,
                                                   min_percentage = @min_score,
                                                   max_percentage = @max_score,
                                                   grade_points = @gpa
                                               WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@grade_letter", tb_gradeletter.Text);
                                cmd.Parameters.AddWithValue("@scale_name", tb_scalename.Text);
                                cmd.Parameters.AddWithValue("@min_score", decimal.Parse(tb_min.Text));
                                cmd.Parameters.AddWithValue("@max_score", decimal.Parse(tb_max.Text));
                                cmd.Parameters.AddWithValue("@gpa", double.Parse(tb_gpa.Text));
                                cmd.Parameters.AddWithValue("@id", _currentGradeScaleId);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                MessageBox.Show(rowsAffected > 0 ? "Grade scale updated successfully!" : "No changes were made.");
                            }
                        }
                        else
                        {
                            string insert = @"INSERT INTO grade_scale 
                                               (grade_letter, scale_name, min_percentage, max_percentage, grade_points) 
                                               VALUES (@grade_letter, @scale_name, @min_score, @max_score, @gpa);
                                               SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@grade_letter", tb_gradeletter.Text);
                                cmd.Parameters.AddWithValue("@scale_name", tb_scalename.Text);
                                cmd.Parameters.AddWithValue("@min_score", decimal.Parse(tb_min.Text));
                                cmd.Parameters.AddWithValue("@max_score", decimal.Parse(tb_max.Text));
                                cmd.Parameters.AddWithValue("@gpa", double.Parse(tb_gpa.Text));

                                _currentGradeScaleId = Convert.ToInt32(cmd.ExecuteScalar());
                                tb_id.Text = _currentGradeScaleId.ToString();
                                MessageBox.Show("Grade scale added successfully!");
                            }
                        }
                    }

                    _isEditMode = false;
                    SetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving grade scale: " + ex.Message);
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("Please enter a Grade Scale ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out int gradeScaleId))
            {
                MessageBox.Show("Invalid Grade Scale ID.");
                return;
            }

            LoadGradeScaleById(gradeScaleId);
            _isEditMode = false;
            SetFormState();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text) || tb_id.Text == "Auto-generated")
            {
                MessageBox.Show("Please enter or search for a valid Grade Scale ID.");
                return;
            }

            if (!int.TryParse(tb_id.Text, out _currentGradeScaleId))
            {
                MessageBox.Show("Invalid Grade Scale ID.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this grade scale?",
                                       "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM grade_scale WHERE id = @id";
                    using (SqlConnection conn = Connectiondb.GetConnection())
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _currentGradeScaleId);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Grade scale deleted successfully.");
                            _currentGradeScaleId = -1;
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("No grade scale was deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting grade scale: " + ex.Message);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            _isEditMode = false;

            if (_currentGradeScaleId > 0)
                LoadGradeScaleById(_currentGradeScaleId);
            else
                ClearForm();

            SetFormState();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Mainboard().Show();
        }

        private void GradeScale_Load_1(object sender, EventArgs e)
        {

        }
    }
}
