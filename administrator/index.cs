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
    }
}
