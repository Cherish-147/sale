 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sale
{
    public partial class Cartltem : Form
    {
        public Cartltem()
        {
            InitializeComponent();
        }
        SqlDataAdapter daCartltem;

        DataSet ds = new DataSet();
        public static decimal pro_sum = 0;
        public static string Goods_id="";

        void init()
        {
            DB.Getcn();
            string str = "select username,Goods_id,ProName,ListPrice,Qty from Cartltem where username='" + Login.username + "'";
            daCartltem =new SqlDataAdapter(str,DB.cn);
            daCartltem.Fill(ds, "cart_info");
        }
        void showAll()
        {
            DataView dvCartltem = new DataView(ds.Tables["cart_info"]);
            dataGridView1.DataSource = dvCartltem;
        }
        void countSum() { 
            if(dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    pro_sum += decimal.Parse(dataGridView1.Rows[i].Cells["ListPrice"].Value.ToString()) *
                        decimal.Parse(dataGridView1.Rows[i].Cells["Qty"].Value.ToString());
                }
            }
        }

        private void Cartltem_Load(object sender, EventArgs e)//窗体加载
        {
            DB.Getcn();
            string str ="select * from Cartltem where username='"+Login.username + "'";
            DataTable dt = DB.GetDataSet(str);

            if(dt.Rows.Count ==0)
            {
                this.Close();
                MessageBox.Show("购物车没有任何商品，请先添加商品到购物车");

                Default d1 = new Default();
                d1.ShowDialog();
            }
            else
            {
                init();
                showAll();
                countSum(); 
            }
            label1.Text ="价格总计："+pro_sum.ToString()+"元";
        }

        private void button1_Click(object sender, EventArgs e)//清空购物车·
        {
            if (dataGridView1.Rows[0].Cells["username"].Value.ToString() == Login.username)
            {
                DB.Getcn();
                //修改商品表中的库存
                string str = "update Goods set Stock_quantity=Stock_quantity+" + int.Parse(dataGridView1.Rows[0].Cells["Stock_quantity"].Value.ToString()) + "'"; 
            }
        }
    }
}
