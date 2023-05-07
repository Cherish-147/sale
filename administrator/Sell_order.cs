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
    public partial class Sell_order : Form
    {
        public Sell_order()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sell_order_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet3.Goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.海产品管理系统DataSet3.Goods);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet2.Employee”中。您可以根据需要移动或移除它。
            this.employeeTableAdapter.Fill(this.海产品管理系统DataSet2.Employee);

        }
    }
}
