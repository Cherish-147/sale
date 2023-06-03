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
    public partial class Formorder : Form
    {
        public Formorder()
        {
            InitializeComponent();
        }
        public static int Order_id;
        void showAll()
        {
            DB.Getcn();
            string str = "select * from [Order]";
            SqlCommand cmd = new SqlCommand(str, DB.cn);
            SqlDataReader rdr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (rdr.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["Column1"].Value = rdr[0];
                dataGridView1.Rows[index].Cells["Column2"].Value = rdr[1];
                dataGridView1.Rows[index].Cells["Column3"].Value = rdr[2];
                dataGridView1.Rows[index].Cells["Column4"].Value = rdr[5];
                dataGridView1.Rows[index].Cells["Column5"].Value = rdr[8];
                dataGridView1.Rows[index].Cells["Column6"].Value = "订单详情";
                dataGridView1.Rows[index].Cells["Column7"].Value = "审核";
            }
            rdr.Close();
            DB.cn.Close();
        }
        private void Formorder_Load(object sender, EventArgs e)
        {
            showAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dataGridView1.CurrentRow.Index;
            int cIndex = e.ColumnIndex;
            if (cIndex == 6)
            {
                dataGridView1.Rows[n].Cells["Column5"].Value = "已审核";
                DB.Getcn();
                string str = "upadte Order set stauts='已审核' where order_id='"
                    + dataGridView1.Rows[n].Cells["Column1"].ToString() + "'";
                DB.Getcn();
            }
            if (cIndex == 5)
            {
                Order_id = int.Parse(dataGridView1.Rows[n].Cells["Column1"].Value.ToString());
                orderitem orl = new orderitem();
                orl.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
