using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale.administrator
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee e1 = new employee();
            e1.Show();
        }

        private void 部门信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            department d1 = new department();
            d1.Show();
        }

        private void 订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sell_order sq =new Sell_order();
            sq.Show();
        }

        private void 商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Goods g1 = new Goods();
            g1.ShowDialog();
        }

        private void 供应商ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier s1 = new supplier();
            s1.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier s1 = new supplier();
            s1.ShowDialog();
        }

        private void 订单审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            administrator.FormOrder fl = new FormOrder();
            fl.ShowDialog();
        }

        private void 商品信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            pro.ShowDialog();
        }
    }
}
