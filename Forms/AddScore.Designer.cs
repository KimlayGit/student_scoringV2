namespace student_scoringV2.Forms
{
    partial class AddScore
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.tb_scorevalue = new System.Windows.Forms.TextBox();
            this.tb_maximumscore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_percentage = new System.Windows.Forms.TextBox();
            this.tb_gradeletter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_studentname = new System.Windows.Forms.ComboBox();
            this.cb_coursename = new System.Windows.Forms.ComboBox();
            this.cb_recordby = new System.Windows.Forms.ComboBox();
            this.cb_classnamae = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label9.Location = new System.Drawing.Point(334, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 37);
            this.label9.TabIndex = 51;
            this.label9.Text = "Course Id:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label8.Location = new System.Drawing.Point(334, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 37);
            this.label8.TabIndex = 50;
            this.label8.Text = "Student Id:";
            // 
            // tb_id
            // 
            this.tb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_id.Location = new System.Drawing.Point(623, 286);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(284, 35);
            this.tb_id.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(334, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 37);
            this.label4.TabIndex = 48;
            this.label4.Text = "Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(483, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 59);
            this.label1.TabIndex = 54;
            this.label1.Text = "Add Score";
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(434, 981);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 61;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(352, 903);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 51);
            this.btn_add.TabIndex = 60;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tb_scorevalue
            // 
            this.tb_scorevalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_scorevalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_scorevalue.Location = new System.Drawing.Point(623, 603);
            this.tb_scorevalue.Name = "tb_scorevalue";
            this.tb_scorevalue.Size = new System.Drawing.Size(284, 35);
            this.tb_scorevalue.TabIndex = 67;
            this.tb_scorevalue.TextChanged += new System.EventHandler(this.tb_scorevalue_TextChanged);
            // 
            // tb_maximumscore
            // 
            this.tb_maximumscore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_maximumscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_maximumscore.Location = new System.Drawing.Point(623, 668);
            this.tb_maximumscore.Name = "tb_maximumscore";
            this.tb_maximumscore.Size = new System.Drawing.Size(284, 35);
            this.tb_maximumscore.TabIndex = 66;
            this.tb_maximumscore.TextChanged += new System.EventHandler(this.tb_maximumscore_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(334, 664);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 37);
            this.label2.TabIndex = 65;
            this.label2.Text = "Maximum Score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(334, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 37);
            this.label3.TabIndex = 64;
            this.label3.Text = "Score Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(334, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 37);
            this.label5.TabIndex = 62;
            this.label5.Text = "Recorded by:";
            // 
            // tb_percentage
            // 
            this.tb_percentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_percentage.Location = new System.Drawing.Point(623, 733);
            this.tb_percentage.Name = "tb_percentage";
            this.tb_percentage.Size = new System.Drawing.Size(284, 35);
            this.tb_percentage.TabIndex = 71;
            // 
            // tb_gradeletter
            // 
            this.tb_gradeletter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_gradeletter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_gradeletter.Location = new System.Drawing.Point(623, 798);
            this.tb_gradeletter.Name = "tb_gradeletter";
            this.tb_gradeletter.Size = new System.Drawing.Size(284, 35);
            this.tb_gradeletter.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(334, 794);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 37);
            this.label6.TabIndex = 69;
            this.label6.Text = "Grade Letter:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(334, 729);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 37);
            this.label7.TabIndex = 68;
            this.label7.Text = "Percentage:";
            // 
            // cb_studentname
            // 
            this.cb_studentname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_studentname.FormattingEnabled = true;
            this.cb_studentname.Location = new System.Drawing.Point(623, 350);
            this.cb_studentname.Name = "cb_studentname";
            this.cb_studentname.Size = new System.Drawing.Size(284, 37);
            this.cb_studentname.TabIndex = 72;
            // 
            // cb_coursename
            // 
            this.cb_coursename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_coursename.FormattingEnabled = true;
            this.cb_coursename.Location = new System.Drawing.Point(623, 415);
            this.cb_coursename.Name = "cb_coursename";
            this.cb_coursename.Size = new System.Drawing.Size(284, 37);
            this.cb_coursename.TabIndex = 73;
            // 
            // cb_recordby
            // 
            this.cb_recordby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_recordby.FormattingEnabled = true;
            this.cb_recordby.Location = new System.Drawing.Point(623, 535);
            this.cb_recordby.Name = "cb_recordby";
            this.cb_recordby.Size = new System.Drawing.Size(284, 37);
            this.cb_recordby.TabIndex = 74;
            // 
            // cb_classnamae
            // 
            this.cb_classnamae.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_classnamae.FormattingEnabled = true;
            this.cb_classnamae.Location = new System.Drawing.Point(623, 470);
            this.cb_classnamae.Name = "cb_classnamae";
            this.cb_classnamae.Size = new System.Drawing.Size(284, 37);
            this.cb_classnamae.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(334, 470);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 37);
            this.label10.TabIndex = 75;
            this.label10.Text = "Class Id:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(652, 981);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(182, 51);
            this.btn_cancel.TabIndex = 79;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(728, 903);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(182, 51);
            this.btn_delete.TabIndex = 78;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(540, 903);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(182, 51);
            this.btn_edit.TabIndex = 77;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(937, 277);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(164, 50);
            this.btn_search.TabIndex = 80;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // AddScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1258, 1259);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.cb_classnamae);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_recordby);
            this.Controls.Add(this.cb_coursename);
            this.Controls.Add(this.cb_studentname);
            this.Controls.Add(this.tb_percentage);
            this.Controls.Add(this.tb_gradeletter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_scorevalue);
            this.Controls.Add(this.tb_maximumscore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label4);
            this.Name = "AddScore";
            this.Text = "AddAssessment";
            this.Load += new System.EventHandler(this.AddScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tb_scorevalue;
        private System.Windows.Forms.TextBox tb_maximumscore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_percentage;
        private System.Windows.Forms.TextBox tb_gradeletter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_studentname;
        private System.Windows.Forms.ComboBox cb_coursename;
        private System.Windows.Forms.ComboBox cb_recordby;
        private System.Windows.Forms.ComboBox cb_classnamae;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_search;
    }
}