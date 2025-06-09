using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_scoringV2.Forms
{
    public partial class Mainboard : Form
    {
        public string Username { get; set; }
        public Mainboard()
        {
            InitializeComponent();
        }

        private void Mainboard_Load(object sender, EventArgs e)
        {
            lb_welcome.Text = $"Welcome, {Username}!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainfrm mainForm = new mainfrm();
            mainForm.Show();
        }

        private void btn_addclass_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddClasses addClasses = new AddClasses();
            addClasses.Show();
        }

        private void btn_addteacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTeacher addTeacher = new AddTeacher();
            addTeacher.Show();
        }

        private void btn_adduser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void btn_adddepartment_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.Show();
        }

        private void btn_addrole_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddRole addRole = new AddRole();
            addRole.Show();
        }

        private void btn_addcourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }

        private void btn_gradescale_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradeScale addGradeScale = new GradeScale();
            addGradeScale.Show();
        }

        private void btn_addstudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddScore addScore = new AddScore();
            addScore.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent viewStudent = new ViewStudent();
            viewStudent.Show();
        }

        private void btn_scorestudent_Click(object sender, EventArgs e)
        {
            this.Close();
            //ViewScore scoreStudent = new ViewScore();
            //scoreStudent.Show();
        }
    }
}
