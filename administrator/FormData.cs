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
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet9.Goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.海产品管理系统DataSet9.Goods);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet8.Employee”中。您可以根据需要移动或移除它。
            this.employeeTableAdapter.Fill(this.海产品管理系统DataSet8.Employee);

        }
    }
}
