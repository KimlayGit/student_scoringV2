namespace student_scoringV2.Forms
{
    partial class AddCourse
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
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_coursename = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_gradescaleid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_departmentid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(535, 737);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 66;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(535, 638);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 51);
            this.btn_add.TabIndex = 65;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(261, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 37);
            this.label3.TabIndex = 64;
            this.label3.Text = "Grade Scale Id:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tb_coursename
            // 
            this.tb_coursename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_coursename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_coursename.Location = new System.Drawing.Point(535, 477);
            this.tb_coursename.Name = "tb_coursename";
            this.tb_coursename.Size = new System.Drawing.Size(284, 35);
            this.tb_coursename.TabIndex = 63;
            this.tb_coursename.TextChanged += new System.EventHandler(this.tb_coursename_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(261, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 37);
            this.label10.TabIndex = 62;
            this.label10.Text = "Department Id:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tb_gradescaleid
            // 
            this.tb_gradescaleid.AcceptsReturn = true;
            this.tb_gradescaleid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_gradescaleid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_gradescaleid.Location = new System.Drawing.Point(535, 422);
            this.tb_gradescaleid.Name = "tb_gradescaleid";
            this.tb_gradescaleid.Size = new System.Drawing.Size(284, 35);
            this.tb_gradescaleid.TabIndex = 61;
            this.tb_gradescaleid.TextChanged += new System.EventHandler(this.tb_gradescaleid_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(525, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 59);
            this.label1.TabIndex = 60;
            this.label1.Text = "Add Course";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_id
            // 
            this.tb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_id.Location = new System.Drawing.Point(535, 291);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(284, 35);
            this.tb_id.TabIndex = 59;
            this.tb_id.TextChanged += new System.EventHandler(this.tb_id_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(261, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 37);
            this.label2.TabIndex = 58;
            this.label2.Text = "ID:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cb_departmentid
            // 
            this.cb_departmentid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_departmentid.FormattingEnabled = true;
            this.cb_departmentid.Location = new System.Drawing.Point(535, 356);
            this.cb_departmentid.Name = "cb_departmentid";
            this.cb_departmentid.Size = new System.Drawing.Size(284, 37);
            this.cb_departmentid.TabIndex = 67;
            this.cb_departmentid.SelectedIndexChanged += new System.EventHandler(this.cb_departmentid_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(261, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 37);
            this.label4.TabIndex = 68;
            this.label4.Text = "Course Name:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 1049);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_departmentid);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_coursename);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_gradescaleid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label2);
            this.Name = "AddCourse";
            this.Text = "AddCourse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_coursename;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_gradescaleid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_departmentid;
        private System.Windows.Forms.Label label4;
    }
}