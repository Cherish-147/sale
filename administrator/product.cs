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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        saleDataContext db = new saleDataContext(); 

        protected void bind()//刷新
        {
            var results = from r in db.Goods
                          select r;
            dataGridView1.DataSource = results;
        }
        private void product_Load(object sender, EventArgs e)//窗体加载
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet5.Supplier”中。您可以根据需要移动或移除它。
            this.supplierTableAdapter.Fill(this.海产品管理系统DataSet5.Supplier);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet4.category”中。您可以根据需要移动或移除它。
            this.categoryTableAdapter.Fill(this.海产品管理系统DataSet4.category);
            bind();
            dataGridView1.Columns[0].Width =60;
            dataGridView1.Columns[1].Width =60;
            dataGridView1.Columns[2].Width =60;
            dataGridView1.Columns[3].Width =60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width =70;
            dataGridView1.Columns[6].Width =70;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width =360;
            dataGridView1.Columns[9].Width =100;
            dataGridView1.Columns[10].Width =100;
        }
    }
}
