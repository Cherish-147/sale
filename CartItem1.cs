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

namespace sale
{
    public partial class CartItem1 : Form
    {
        public CartItem1()
        {
            InitializeComponent();
        }
        SqlDataAdapter daCartltem;

        DataSet ds = new DataSet();
        public static decimal pro_sum = 0;
        //public static int Qty1 = 1;
        public static string Goods_id1 = "";

        void init()
        {
            DB.Getcn();
            string str = "select username,Goods_id,ProName,ListPrice,Qty from Cartltem where username='" + Login.username + "'";
            daCartltem = new SqlDataAdapter(str, DB.cn);
            daCartltem.Fill(ds, "cart_info");
        }
        void showAll()
        {
            DataView dvCartltem = new DataView(ds.Tables["cart_info"]);
            dataGridView1.DataSource = dvCartltem;
        }
        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "用户名";
            this.dataGridView1.Columns[1].HeaderText = "商品编号";
            this.dataGridView1.Columns[2].HeaderText = "商品名称";
            this.dataGridView1.Columns[3].HeaderText = "单价";
            this.dataGridView1.Columns[4].HeaderText = "购买数量";

        }

        void countSum()//总计价格
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    pro_sum += decimal.Parse(dataGridView1.Rows[i].Cells["ListPrice"].Value.ToString()) *
                        decimal.Parse(dataGridView1.Rows[i].Cells["Qty"].Value.ToString());
                }
            }
        }

        private void CartItem1_Load(object sender, EventArgs e)//窗体加载
        {
            DB.Getcn();
            string str = "select * from Cartltem where username='" + Login.username + "'";
            DataTable dt = DB.GetDataSet(str);

            if (dt.Rows.Count == 0)
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
                dgvHead();
                countSum();
            }
            label1.Text = "价格总计：" + pro_sum.ToString() + "元";
        }

        private void button1_Click(object sender, EventArgs e)//清空购物车
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int n = dataGridView1.Rows.Count - 1;
                for (int i = 0; i < n; i++)
                {
                    if (dataGridView1.Rows[0].Cells["username"].Value.ToString() == Login.username)
                    {
                        DB.Getcn();
                        //修改商品表中的库存
                        string str = "update Goods set Stock_quantity = Stock_quantity+" +
                                int.Parse(dataGridView1.Rows[0].Cells["Qty"].Value.ToString())
                                + "where Goods_id='" +
                                dataGridView1.Rows[0].Cells["Goods_id"].Value.ToString() + "'";
                        DB.sqlEx(str);

                        dataGridView1.Rows.RemoveAt(0);
                    }
                }
                try
                {
                    DB.Getcn();
                    string str = "delete from Cartltem where username ='" + Login.username + "'";
                    DB.sqlEx(str);
                    MessageBox.Show("购物车已清空");
                    label1.Text = "价格总计：0元";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DB.cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)//结算
        {
            Order1 order1 = new Order1();
            order1.ShowDialog();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        Goods_id1 = dataGridView1.Rows[i].Cells["Goods_id"].Value.ToString();
                    }

                }
            }
            if (Goods_id1 == "")
            {
                MessageBox.Show("请选择一项商品，再点击购买");

            }
            else
            {
                this.Dispose();
                Dialog_buy d1 = new Dialog_buy();
                d1.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)//关闭
        {
            this.Dispose();
            pro_sum = 0;
            Default d1 = new Default();
            d1.ShowDialog();
        }
    }
}
