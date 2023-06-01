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
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            InitializeComponent();
        }
        public static int OrderId;

        void showAll()//显示全部
        {
            DB.Getcn();
            string str = "select * from order";
            SqlCommand sqlCommand = new SqlCommand(str,DB.cn);
            dataGridView1.Rows.Clear();
            //while (rdr.Read())
            //{
            //    int index = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[index].Cells["Column1"].Value = rdr[0];

            //}
        }
    }
}
