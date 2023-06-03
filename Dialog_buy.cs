using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sale
{
    public partial class Dialog_buy : Form
    {
        public Dialog_buy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//提交
        {
            if (textbox_buynum.Text == "")
            {
                MessageBox.Show("请输入购买数量");
            }
            else
            {
                if (int.Parse(textbox_buynum.Text) > int.Parse(kucun.Text))
                {
                    MessageBox.Show("购买数量不能大于库存");
                }
                else
                {
                    //修改产品表中的库存
                    String str = "update Goods set Stock_quantity=Stock_quantity-" + int.Parse(textbox_buynum.Text) + "where Goods_id='" + Default.Goods_id + "'";
                    DB.sqlEx(str);
                    //判断该商品是否存在购物车中。如果存在就修改购买数量，否则增加一条新的购买记录
                    DB.Getcn();
                    string sdr = "select * from Cartltem where username='" + Login.username + "'and Goods_id='" + Default.Goods_id + "'";
                    DataTable dt = DB.GetDataSet(sdr);
                    if (dt.Rows.Count > 0)
                    {
                        string sfr = "update Cartltem set Qty=Qty+" + int.Parse(textbox_buynum.Text) + "where username='" + Login.username + "'and Goods_id='" + Default.Goods_id + "'";
                        DB.sqlEx(sfr);
                    }
                    else
                    {
                        string ser = "insert into Cartltem  values('" + Login.username + "'," + int.Parse(Default.Goods_id) + ",'" 
                            + name.Text + "'," + decimal.Parse(kucun.Text) + "," + int.Parse(textbox_buynum.Text) + ")";
                        //string ser = "insert into 购物车表 values('" + Login.username + "',"
                        //+ int.Parse(Default.go_id) + ",'"
                        //+ name.Text + "'," + decimal.Parse(textBox1.Text) + "," + int.Parse(textBox3.Text) + ")"; 
                        DB.sqlEx(ser);

                    }
                    Default.Goods_id = "";
                    MessageBox.Show("已添加到购物车");
                    this.Dispose();//关闭当前窗体并释放资源
                    Default dl = new Default();
                    dl.ShowDialog();

                }
            }
        }

        private void Dialog_buy_Load(object sender, EventArgs e)//窗体加载
        {
            DB.Getcn();
            string str = "select * from Goods where Goods_id='" + Default.Goods_id + "'";
            DataTable dt = DB.GetDataSet(str);
            if (dt.Rows.Count > 0)
            {
                name.Text = dt.Rows[0][1].ToString();
                dj.Text = dt.Rows[0][4].ToString();
                kucun.Text = dt.Rows[0][5].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)//返回
        {
            Default.Goods_id = "";
            this.Dispose();
            Default d1 = new Default();
            d1.ShowDialog();

        }
    }
}
