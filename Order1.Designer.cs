namespace sale
{
    partial class Order1
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
            this.city = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.TextBox();
            this.citys = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.zip = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "省(直辖市、自治区)";
            // 
            // city
            // 
            this.city.AutoSize = true;
            this.city.Location = new System.Drawing.Point(148, 81);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(29, 12);
            this.city.TabIndex = 1;
            this.city.Text = "城市";
            // 
            // Add
            // 
            this.Add.AutoSize = true;
            this.Add.Location = new System.Drawing.Point(150, 121);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(29, 12);
            this.Add.TabIndex = 2;
            this.Add.Text = "地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "邮政编码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "电话";
            // 
            // state
            // 
            this.state.Location = new System.Drawing.Point(265, 24);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(100, 21);
            this.state.TabIndex = 5;
            // 
            // citys
            // 
            this.citys.Location = new System.Drawing.Point(238, 71);
            this.citys.Name = "citys";
            this.citys.Size = new System.Drawing.Size(100, 21);
            this.citys.TabIndex = 6;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(238, 121);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(100, 21);
            this.Address.TabIndex = 7;
            // 
            // zip
            // 
            this.zip.Location = new System.Drawing.Point(238, 165);
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(100, 21);
            this.zip.TabIndex = 8;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(238, 208);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(100, 21);
            this.Phone.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Order1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.zip);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.citys);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.city);
            this.Controls.Add(this.label1);
            this.Name = "Order1";
            this.Text = "Order1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label city;
        private System.Windows.Forms.Label Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.TextBox citys;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox zip;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}