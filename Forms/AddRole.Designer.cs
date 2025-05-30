namespace student_scoringV2.Forms
{
    partial class AddRole
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_rolename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(161, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 37);
            this.label3.TabIndex = 55;
            this.label3.Text = "Code:";
            // 
            // tb_code
            // 
            this.tb_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_code.Location = new System.Drawing.Point(435, 559);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(284, 35);
            this.tb_code.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(161, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 37);
            this.label10.TabIndex = 53;
            this.label10.Text = "Role Name:";
            // 
            // tb_rolename
            // 
            this.tb_rolename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_rolename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_rolename.Location = new System.Drawing.Point(435, 481);
            this.tb_rolename.Name = "tb_rolename";
            this.tb_rolename.Size = new System.Drawing.Size(284, 35);
            this.tb_rolename.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(425, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 59);
            this.label1.TabIndex = 51;
            this.label1.Text = "Add Role";
            // 
            // tb_id
            // 
            this.tb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_id.Location = new System.Drawing.Point(435, 416);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(284, 35);
            this.tb_id.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(161, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 37);
            this.label2.TabIndex = 49;
            this.label2.Text = "ID:";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(435, 674);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 51);
            this.btn_add.TabIndex = 56;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(435, 773);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(182, 51);
            this.btn_back.TabIndex = 57;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // AddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 1039);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_rolename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label2);
            this.Name = "AddRole";
            this.Text = "AddRole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_rolename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_back;
    }
}