namespace student_scoringV2.Forms
{
    partial class ViewScore
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
            this.dgv_studentscore = new System.Windows.Forms.DataGridView();
            this.btn_back = new System.Windows.Forms.Button();
            this.cb_searchtype = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_seach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_studentscore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(578, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 59);
            this.label1.TabIndex = 72;
            this.label1.Text = "Student Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgv_studentscore
            // 
            this.dgv_studentscore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_studentscore.Location = new System.Drawing.Point(31, 319);
            this.dgv_studentscore.Name = "dgv_studentscore";
            this.dgv_studentscore.RowHeadersWidth = 62;
            this.dgv_studentscore.RowTemplate.Height = 28;
            this.dgv_studentscore.Size = new System.Drawing.Size(1434, 762);
            this.dgv_studentscore.TabIndex = 73;
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(680, 1124);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 78;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // cb_searchtype
            // 
            this.cb_searchtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_searchtype.FormattingEnabled = true;
            this.cb_searchtype.Location = new System.Drawing.Point(394, 207);
            this.cb_searchtype.Name = "cb_searchtype";
            this.cb_searchtype.Size = new System.Drawing.Size(284, 37);
            this.cb_searchtype.TabIndex = 88;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label11.Location = new System.Drawing.Point(120, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 37);
            this.label11.TabIndex = 87;
            this.label11.Text = "Search Type:";
            // 
            // tb_seach
            // 
            this.tb_seach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_seach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_seach.Location = new System.Drawing.Point(1024, 207);
            this.tb_seach.Name = "tb_seach";
            this.tb_seach.Size = new System.Drawing.Size(284, 35);
            this.tb_seach.TabIndex = 86;
            this.tb_seach.TextChanged += new System.EventHandler(this.tb_seach_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(875, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 37);
            this.label2.TabIndex = 85;
            this.label2.Text = "Search:";
            // 
            // ViewScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1517, 1217);
            this.Controls.Add(this.cb_searchtype);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_seach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.dgv_studentscore);
            this.Controls.Add(this.label1);
            this.Name = "ViewScore";
            this.Text = "ViewScore";
            this.Load += new System.EventHandler(this.ViewScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_studentscore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_studentscore;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.ComboBox cb_searchtype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_seach;
        private System.Windows.Forms.Label label2;
    }
}