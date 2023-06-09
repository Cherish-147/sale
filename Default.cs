﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
namespace sale
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
        }
        SqlDataAdapter daProduct;//适配器对象
        DataSet ds =new DataSet();//
        public static string Goods_id="";
        void init()//
        {
            DB.Getcn();
            string str = "select Goods_id,Classification_id,Supplier_id,Goods_name,Stock_quantity from Goods";
            daProduct = new SqlDataAdapter(str, DB.cn);//
            daProduct.Fill(ds,"pro_info");//
        }
        void showAll()
        {
            DataView dvProduct = new DataView(ds.Tables["pro_info"]);//
            dataGridView1.DataSource =dvProduct;//

        }
        private void Default_Load(object sender, EventArgs e)//响应事件
        {
            label2.Text=Login.username;
            init();
            
            dvgProduct();
            showAll();
            dgvHead();

            showXz();
            
            label2.Text = Login.username;

        }
        void dgvHead()//
        {
            this.dataGridView1.Columns[0].HeaderText = "产品编号";
            this.dataGridView1.Columns[1].HeaderText = "产品类型";
            this.dataGridView1.Columns[2].HeaderText = "供应商编号";
            this.dataGridView1.Columns[3].HeaderText = "产品名称";
            this.dataGridView1.Columns[4].HeaderText = "库存";

        }
        void showXz()//显示选择项
        {
            DataGridViewCheckBoxColumn acCOde = new DataGridViewCheckBoxColumn();
            acCOde.Name = "acCode";
            dataGridView1.Columns.Add(acCOde);
        }
        void dvgProduct()//加载产品编号
        {
            DataView dvProduct = new DataView(ds.Tables["pro_info"]);
            comboBox1.DisplayMember = "Goods_id";
            comboBox1.ValueMember = "Goods_id";
            comboBox1.DataSource = dvProduct;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CHpwd ch1 =new CHpwd();
            ch1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dvProID = new DataView(ds.Tables["pro_info"]);
            dvProID.RowFilter = "Goods_id='" + comboBox1.SelectedValue.ToString()+"'";
            dataGridView1.DataSource = dvProID;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void button3_Click(object sender, EventArgs e)//模糊查询
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入查询关键字");

            }
            else
            {
                DataView dvName = new DataView(ds.Tables["pro_info"]);
                dvName.RowFilter= " Goods_name like'%" + textBox1.Text+"%'";
                if (dvName.Count < 1)
                {
                    MessageBox.Show("没有查询到匹配的结果");
                }
                else
                {
                    dataGridView1.DataSource=dvName;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i=0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dataGridView1.Rows[i].Cells["acCode"] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                    {
                        ck.Value=false;
                    }
                    else
                    {
                        ck.Value = true;
                    }

                }
            }
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                       // Goods_id = dataGridView1.Rows[i].Cells["Goods_id"].Value.ToString();
                        Goods_id = dataGridView1.Rows[i].Cells["Goods_id"].Value.ToString();
                    }
                }
            }
            CHX_Product ch1 = new CHX_Product();
            ch1.Show();
        }

        private void btn_buy_Click(object sender, EventArgs e)//购买
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        Goods_id = dataGridView1.Rows[i].Cells["Goods_id"].Value.ToString();
                    }
                }
            }
            if (Goods_id == "")
            {
                MessageBox.Show("请选择一项商品，再点击购买");
            }
            else
            {
                this.Dispose();
                Dialog_buy ch3 = new Dialog_buy();
                ch3.Show();
            }

        }

        private void button6_Click(object sender, EventArgs e)//查看购物车
        {
           // Cartltem ch4 = new Cartltem();//严重性	代码	说明	项目	文件	行	禁止显示状态错误 CS0121  以下方法或属性之间的调用具有二义性:“Cartltem.Cartltem()”和“Cartltem.Cartltem()”	sale F:\C#\sales\sale\Default.cs	185	活动
           CartItem1 ch4 = new CartItem1();
            ch4.Show();
        }
    }
}
