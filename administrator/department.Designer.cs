namespace sale.administrator
{
    partial class department
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRoback = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.text_Telephone = new System.Windows.Forms.TextBox();
            this.text_Manager_id = new System.Windows.Forms.TextBox();
            this.text_Manager = new System.Windows.Forms.TextBox();
            this.text_department_name = new System.Windows.Forms.TextBox();
            this.text_Department_description = new System.Windows.Forms.TextBox();
            this.text_department_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.text_department_id2 = new System.Windows.Forms.TextBox();
            this.text_Department_description2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.text_department_name2 = new System.Windows.Forms.TextBox();
            this.text_Manager2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.text_Manager_id2 = new System.Windows.Forms.TextBox();
            this.text_Telephone2 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel2 = new System.Windows.Forms.Button();
            this.btnRoback2 = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前用户是：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnRoback);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.text_Telephone);
            this.groupBox1.Controls.Add(this.text_Manager_id);
            this.groupBox1.Controls.Add(this.text_Manager);
            this.groupBox1.Controls.Add(this.text_department_name);
            this.groupBox1.Controls.Add(this.text_Department_description);
            this.groupBox1.Controls.Add(this.text_department_id);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 328);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加部门信息加*号必填";
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDel.Location = new System.Drawing.Point(642, 265);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 47);
            this.btnDel.TabIndex = 16;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSave.Location = new System.Drawing.Point(795, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 47);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRoback
            // 
            this.btnRoback.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRoback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRoback.Location = new System.Drawing.Point(461, 265);
            this.btnRoback.Name = "btnRoback";
            this.btnRoback.Size = new System.Drawing.Size(100, 47);
            this.btnRoback.TabIndex = 14;
            this.btnRoback.Text = "撤销";
            this.btnRoback.UseVisualStyleBackColor = true;
            this.btnRoback.Click += new System.EventHandler(this.btnRoback_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnReset.Location = new System.Drawing.Point(281, 265);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 47);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAdd.Location = new System.Drawing.Point(99, 265);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 47);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // text_Telephone
            // 
            this.text_Telephone.Location = new System.Drawing.Point(795, 144);
            this.text_Telephone.Name = "text_Telephone";
            this.text_Telephone.Size = new System.Drawing.Size(100, 21);
            this.text_Telephone.TabIndex = 11;
            // 
            // text_Manager_id
            // 
            this.text_Manager_id.Location = new System.Drawing.Point(795, 30);
            this.text_Manager_id.Name = "text_Manager_id";
            this.text_Manager_id.Size = new System.Drawing.Size(100, 21);
            this.text_Manager_id.TabIndex = 10;
            // 
            // text_Manager
            // 
            this.text_Manager.Location = new System.Drawing.Point(461, 144);
            this.text_Manager.Name = "text_Manager";
            this.text_Manager.Size = new System.Drawing.Size(100, 21);
            this.text_Manager.TabIndex = 9;
            // 
            // text_department_name
            // 
            this.text_department_name.Location = new System.Drawing.Point(461, 33);
            this.text_department_name.Name = "text_department_name";
            this.text_department_name.Size = new System.Drawing.Size(100, 21);
            this.text_department_name.TabIndex = 8;
            // 
            // text_Department_description
            // 
            this.text_Department_description.Location = new System.Drawing.Point(99, 150);
            this.text_Department_description.Multiline = true;
            this.text_Department_description.Name = "text_Department_description";
            this.text_Department_description.Size = new System.Drawing.Size(123, 74);
            this.text_Department_description.TabIndex = 7;
            // 
            // text_department_id
            // 
            this.text_department_id.Location = new System.Drawing.Point(99, 33);
            this.text_department_id.Name = "text_department_id";
            this.text_department_id.Size = new System.Drawing.Size(100, 21);
            this.text_department_id.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(693, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "管理者名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "部门描述";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(693, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "管理者编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "部门名*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "部门编号*";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(113, 370);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(759, 218);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 613);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "部门编号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 691);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "部门描述";
            // 
            // text_department_id2
            // 
            this.text_department_id2.Location = new System.Drawing.Point(113, 613);
            this.text_department_id2.Name = "text_department_id2";
            this.text_department_id2.ReadOnly = true;
            this.text_department_id2.Size = new System.Drawing.Size(100, 21);
            this.text_department_id2.TabIndex = 6;
            // 
            // text_Department_description2
            // 
            this.text_Department_description2.Location = new System.Drawing.Point(105, 687);
            this.text_Department_description2.Multiline = true;
            this.text_Department_description2.Name = "text_Department_description2";
            this.text_Department_description2.Size = new System.Drawing.Size(123, 74);
            this.text_Department_description2.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(394, 613);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "部门名*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(394, 691);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "管理者名";
            // 
            // text_department_name2
            // 
            this.text_department_name2.Location = new System.Drawing.Point(475, 613);
            this.text_department_name2.Name = "text_department_name2";
            this.text_department_name2.Size = new System.Drawing.Size(100, 21);
            this.text_department_name2.TabIndex = 10;
            // 
            // text_Manager2
            // 
            this.text_Manager2.Location = new System.Drawing.Point(475, 691);
            this.text_Manager2.Name = "text_Manager2";
            this.text_Manager2.Size = new System.Drawing.Size(100, 21);
            this.text_Manager2.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(709, 613);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "管理者编号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(709, 691);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "电话";
            // 
            // text_Manager_id2
            // 
            this.text_Manager_id2.Location = new System.Drawing.Point(809, 613);
            this.text_Manager_id2.Name = "text_Manager_id2";
            this.text_Manager_id2.Size = new System.Drawing.Size(100, 21);
            this.text_Manager_id2.TabIndex = 14;
            // 
            // text_Telephone2
            // 
            this.text_Telephone2.Location = new System.Drawing.Point(809, 691);
            this.text_Telephone2.Name = "text_Telephone2";
            this.text_Telephone2.Size = new System.Drawing.Size(100, 21);
            this.text_Telephone2.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdate.Location = new System.Drawing.Point(113, 816);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 47);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel2
            // 
            this.btnDel2.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnDel2.Location = new System.Drawing.Point(571, 816);
            this.btnDel2.Name = "btnDel2";
            this.btnDel2.Size = new System.Drawing.Size(100, 47);
            this.btnDel2.TabIndex = 17;
            this.btnDel2.Text = "删除";
            this.btnDel2.UseVisualStyleBackColor = true;
            // 
            // btnRoback2
            // 
            this.btnRoback2.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRoback2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRoback2.Location = new System.Drawing.Point(347, 816);
            this.btnRoback2.Name = "btnRoback2";
            this.btnRoback2.Size = new System.Drawing.Size(100, 47);
            this.btnRoback2.TabIndex = 18;
            this.btnRoback2.Text = "撤销";
            this.btnRoback2.UseVisualStyleBackColor = true;
            this.btnRoback2.Click += new System.EventHandler(this.btnRoback2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSave2.Location = new System.Drawing.Point(809, 816);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(100, 47);
            this.btnSave2.TabIndex = 19;
            this.btnSave2.Text = "保存";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 896);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnRoback2);
            this.Controls.Add(this.btnDel2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.text_Telephone2);
            this.Controls.Add(this.text_Manager_id2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.text_Manager2);
            this.Controls.Add(this.text_department_name2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text_Department_description2);
            this.Controls.Add(this.text_department_id2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "department";
            this.Text = "department";
            this.Load += new System.EventHandler(this.department_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_Manager;
        private System.Windows.Forms.TextBox text_department_name;
        private System.Windows.Forms.TextBox text_Department_description;
        private System.Windows.Forms.TextBox text_department_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_Manager_id;
        private System.Windows.Forms.TextBox text_Telephone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRoback;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_department_id2;
        private System.Windows.Forms.TextBox text_Department_description2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox text_department_name2;
        private System.Windows.Forms.TextBox text_Manager2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox text_Manager_id2;
        private System.Windows.Forms.TextBox text_Telephone2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel2;
        private System.Windows.Forms.Button btnRoback2;
        private System.Windows.Forms.Button btnSave2;
    }
}