namespace student_scoringV2.Forms
{
    partial class AddDepartment
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
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_departmentname = new System.Windows.Forms.TextBox();
            this.cb_headofdepartment = new System.Windows.Forms.ComboBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(168, 493);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(321, 37);
            this.label10.TabIndex = 44;
            this.label10.Text = "Head Of Department:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(474, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 59);
            this.label1.TabIndex = 42;
            this.label1.Text = "Add Department";
            // 
            // tb_id
            // 
            this.tb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_id.Location = new System.Drawing.Point(528, 428);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(284, 35);
            this.tb_id.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(432, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 37);
            this.label2.TabIndex = 40;
            this.label2.Text = "ID:";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(484, 841);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 51);
            this.btn_add.TabIndex = 51;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(201, 563);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 37);
            this.label3.TabIndex = 53;
            this.label3.Text = "Department Name:";
            // 
            // tb_departmentname
            // 
            this.tb_departmentname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_departmentname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_departmentname.Location = new System.Drawing.Point(528, 563);
            this.tb_departmentname.Name = "tb_departmentname";
            this.tb_departmentname.Size = new System.Drawing.Size(284, 35);
            this.tb_departmentname.TabIndex = 52;
            // 
            // cb_headofdepartment
            // 
            this.cb_headofdepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_headofdepartment.FormattingEnabled = true;
            this.cb_headofdepartment.Location = new System.Drawing.Point(528, 493);
            this.cb_headofdepartment.Name = "cb_headofdepartment";
            this.cb_headofdepartment.Size = new System.Drawing.Size(284, 37);
            this.cb_headofdepartment.TabIndex = 54;
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(484, 937);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 58;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // tb_code
            // 
            this.tb_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_code.Location = new System.Drawing.Point(528, 622);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(284, 35);
            this.tb_code.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(201, 618);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 37);
            this.label4.TabIndex = 60;
            this.label4.Text = "Code:";
            // 
            // AddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 1133);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.cb_headofdepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_departmentname);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label2);
            this.Name = "AddDepartment";
            this.Text = "AddDepartment";
            this.Load += new System.EventHandler(this.AddDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_departmentname;
        private System.Windows.Forms.ComboBox cb_headofdepartment;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label label4;
    }
}