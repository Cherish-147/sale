using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale.administrator
{
    public partial class orderitem : Form
    {
        public orderitem()
        {
            InitializeComponent();
        }
        SqlDataAdapter daorderItem;
        DataSet ds = new DataSet();
        void init()
        {
            DB.Getcn();
            string str = "select * from OrderItem where order_id=" + Formorder.Order_id + "";
            daorderItem = new SqlDataAdapter(str, DB.cn);
            daorderItem.Fill(ds, "orderItem_info");
        }
        void showAll()
        {
            DataView dvorderItem = new DataView(ds.Tables["orderItem_info"]);
            dataGridView1.DataSource = dvorderItem;
        }
        private void orderitem_Load(object sender, EventArgs e)
        {
            init();
            showAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
