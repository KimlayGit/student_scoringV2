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
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tb_typename.Text))
            {
                MessageBox.Show("Please enter the Assessment Name.");
                tb_typename.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tb_gradecal.Text))
            {
                MessageBox.Show("Please enter the Description.");
                tb_gradecal.Focus();
                return;
            }
        }
    }
}
