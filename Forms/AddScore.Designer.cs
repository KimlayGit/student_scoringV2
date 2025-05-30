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
            this.tb_typename = new System.Windows.Forms.TextBox();
            this.tb_gradecal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_typename
            // 
            this.tb_typename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_typename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_typename.Location = new System.Drawing.Point(623, 354);
            this.tb_typename.Name = "tb_typename";
            this.tb_typename.Size = new System.Drawing.Size(284, 35);
            this.tb_typename.TabIndex = 53;
            // 
            // tb_gradecal
            // 
            this.tb_gradecal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_gradecal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_gradecal.Location = new System.Drawing.Point(623, 419);
            this.tb_gradecal.Name = "tb_gradecal";
            this.tb_gradecal.Size = new System.Drawing.Size(284, 35);
            this.tb_gradecal.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label9.Location = new System.Drawing.Point(334, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(283, 37);
            this.label9.TabIndex = 51;
            this.label9.Text = "Grade Calculation:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label8.Location = new System.Drawing.Point(334, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 37);
            this.label8.TabIndex = 50;
            this.label8.Text = "Type Name:";
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
            this.btn_back.Location = new System.Drawing.Point(536, 765);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 61;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(536, 690);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 51);
            this.btn_add.TabIndex = 60;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1258, 1259);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_typename);
            this.Controls.Add(this.tb_gradecal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label4);
            this.Name = "AddScore";
            this.Text = "AddAssessment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_typename;
        private System.Windows.Forms.TextBox tb_gradecal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_add;
    }
}