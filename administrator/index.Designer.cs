namespace sale.administrator
{
    partial class index
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.部门ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.部门信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.员工ToolStripMenuItem,
            this.部门ToolStripMenuItem,
            this.商品ToolStripMenuItem,
            this.订单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1229, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 员工ToolStripMenuItem
            // 
            this.员工ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.员工信息ToolStripMenuItem});
            this.员工ToolStripMenuItem.Name = "员工ToolStripMenuItem";
            this.员工ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.员工ToolStripMenuItem.Text = "员工";
            // 
            // 员工信息ToolStripMenuItem
            // 
            this.员工信息ToolStripMenuItem.Name = "员工信息ToolStripMenuItem";
            this.员工信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.员工信息ToolStripMenuItem.Text = "员工信息";
            this.员工信息ToolStripMenuItem.Click += new System.EventHandler(this.员工信息ToolStripMenuItem_Click);
            // 
            // 部门ToolStripMenuItem
            // 
            this.部门ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.部门信息ToolStripMenuItem});
            this.部门ToolStripMenuItem.Name = "部门ToolStripMenuItem";
            this.部门ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.部门ToolStripMenuItem.Text = "部门";
            // 
            // 商品ToolStripMenuItem
            // 
            this.商品ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品信息ToolStripMenuItem});
            this.商品ToolStripMenuItem.Name = "商品ToolStripMenuItem";
            this.商品ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.商品ToolStripMenuItem.Text = "商品";
            // 
            // 订单ToolStripMenuItem
            // 
            this.订单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.订单信息ToolStripMenuItem});
            this.订单ToolStripMenuItem.Name = "订单ToolStripMenuItem";
            this.订单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.订单ToolStripMenuItem.Text = "订单";
            // 
            // 部门信息ToolStripMenuItem
            // 
            this.部门信息ToolStripMenuItem.Name = "部门信息ToolStripMenuItem";
            this.部门信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.部门信息ToolStripMenuItem.Text = "部门信息";
            this.部门信息ToolStripMenuItem.Click += new System.EventHandler(this.部门信息ToolStripMenuItem_Click);
            // 
            // 商品信息ToolStripMenuItem
            // 
            this.商品信息ToolStripMenuItem.Name = "商品信息ToolStripMenuItem";
            this.商品信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.商品信息ToolStripMenuItem.Text = "商品信息";
            // 
            // 订单信息ToolStripMenuItem
            // 
            this.订单信息ToolStripMenuItem.Name = "订单信息ToolStripMenuItem";
            this.订单信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.订单信息ToolStripMenuItem.Text = "订单信息";
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 627);
            this.Controls.Add(this.menuStrip1);
            this.Name = "index";
            this.Text = "index";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 员工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 部门ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 员工信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 部门信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单信息ToolStripMenuItem;
    }
}