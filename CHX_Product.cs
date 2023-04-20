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
    public partial class CHX_Product : Form
    {
        public CHX_Product()
        {
            InitializeComponent();
        }

        private void CHX_Product_Load(object sender, EventArgs e)
        {
            DB.Getcn();
            string sdr = "select Classifcation_name from category where Classifcation_id=(select Classifcation_id from Goods where Goods_id ='"
            + Default.Goods_id + "')";//查询类别名称
            DataTable dt =DB.GetDataSet(sdr);
            string str = "select * from Goods where Goods_id= '"
                + Default.Goods_id + "'";//查询产品详细信息




            SqlCommand cmd = new SqlCommand(str, DB.cn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                MessageBox.Show("没有相关查询结果");

            }
            else
            {
                while (rdr.Read())
                {
                    label2.Text = rdr[0].ToString();
                    label4.Text = rdr[1].ToString();
                    label6.Text = rdr[2].ToString();
                    label8.Text = rdr[3].ToString();
                    label10.Text = rdr[4].ToString();
                    label12.Text = rdr[5].ToString();
                    label14.Text = rdr[6].ToString();
                    label16.Text = rdr[7].ToString();
                    pictureBox1.Image=Image.FromFile(Application.StartupPath + "" + rdr[8].ToString() + "");//加载图片
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//自适应图片尺寸大小
                    //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    label8.Text = dt.Rows[0][0].ToString();//显示类别名称
                    

                    listBox1.Items.Add("  产品编号" + rdr[0]);
                    listBox1.Items.Add("  产品名称" + rdr[1]);
                    listBox1.Items.Add("  类别编号" + rdr[2]);
                    listBox1.Items.Add("  类别名称" + dt.Rows[0][0].ToString());
                    listBox1.Items.Add("  单价" + rdr[4]);
                    listBox1.Items.Add("  库存数量" + rdr[5]);
                    listBox1.Items.Add("  订单量" + rdr[6]);
                    listBox1.Items.Add("  仓库编号" + rdr[7]);

                }
                rdr.Close();
            }DB.cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           //点多了响应事件不可删除
        }
    }
}
