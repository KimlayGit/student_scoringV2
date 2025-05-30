namespace student_scoringV2.Forms
{
    partial class ViewStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid_student = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_student)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(525, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 59);
            this.label1.TabIndex = 43;
            this.label1.Text = "View Students";
            // 
            // cb_class
            // 
            this.cb_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(401, 226);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(284, 37);
            this.cb_class.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label11.Location = new System.Drawing.Point(127, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 37);
            this.label11.TabIndex = 83;
            this.label11.Text = "Search Type:";
            // 
            // tb_id
            // 
            this.tb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_id.Location = new System.Drawing.Point(1031, 226);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(284, 35);
            this.tb_id.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(882, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 37);
            this.label2.TabIndex = 81;
            this.label2.Text = "Search:";
            // 
            // dataGrid_student
            // 
            this.dataGrid_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_student.Location = new System.Drawing.Point(48, 370);
            this.dataGrid_student.Name = "dataGrid_student";
            this.dataGrid_student.RowHeadersWidth = 62;
            this.dataGrid_student.RowTemplate.Height = 28;
            this.dataGrid_student.Size = new System.Drawing.Size(1322, 669);
            this.dataGrid_student.TabIndex = 85;
            this.dataGrid_student.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_student_CellContentClick);
            // 
            // ViewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 1156);
            this.Controls.Add(this.dataGrid_student);
            this.Controls.Add(this.cb_class);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewStudent";
            this.Text = "ViewStudent";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_student)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGrid_student;
    }
}