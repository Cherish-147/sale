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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Data.Common;
using System.Reflection.Emit;

namespace sale.administrator
{
    public partial class Goods1 : Form
    {
        public Goods1()
        {
            InitializeComponent();
        }
        SqlDataAdapter daLog, daGoods;
        DataSet ds = new DataSet();
        public static string goods_id = "";
        public static int index_id;
        internal string Image;

        public Goods1(string image)
        {
            Image = image;
        }

        void init()//初始化函数
        {
            DB.Getcn();
            string str = "select * from Goods";
            string slr = "select * from log";

            daGoods = new SqlDataAdapter(str, DB.cn);
            daLog = new SqlDataAdapter(slr, DB.cn);

            daLog.Fill(ds, "log_info");
            daGoods.Fill(ds, "goods_info");
            DB.cn.Close();
        }

        void showAll()//显示全部
        {
            DataView dvGoods = new DataView(ds.Tables["goods_info"]);
            dataGridView1.DataSource = dvGoods;
        }

        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "商品编号";
            this.dataGridView1.Columns[1].HeaderText = "商品名称";
            this.dataGridView1.Columns[2].HeaderText = "商品编号";
            this.dataGridView1.Columns[3].HeaderText = "供应商编号";
            this.dataGridView1.Columns[4].HeaderText = "单价";

            this.dataGridView1.Columns[5].HeaderText = "库存数量";
            this.dataGridView1.Columns[6].HeaderText = "订单数量";
            this.dataGridView1.Columns[7].HeaderText = "仓库编号";
            
            this.dataGridView1.Columns[8].HeaderText = "图片";
   
        }
          void showXz()//显示选择列
                {
                    DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
                    acCode.Name = "acCode";
                    acCode.HeaderText = "选择";
                    dataGridView1.Columns.Add(acCode);
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//所有列自适应
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dataGridView1.Rows[i].Cells["acCode"] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                    {
                        ck.Value = false;
                    }
                    else
                    {
                        ck.Value = true;
                    }

                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        //text_id2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //text_name2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        //combo_sex2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        //dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        //dateTimePicker4.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        //text_address2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        //text_phone2.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        //text_wages2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();



                        //DataRow[] daDepartment = ds.Tables["department_info"].Select("Department_id='"
                        //    + dataGridView1.Rows[i].Cells[8].Value.ToString() + "'");



                    }
                }
            }   }

        private void btndel_Click(object sender, EventArgs e)//删除
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString() == "True")
                {
                        goods_id = dataGridView1.Rows[i].Cells["goods_id"].Value.ToString();//获取被选中的行部门编号
                        index_id = i;//获取选择行的索引
                    
                }
            }
            if (goods_id =="")
            {
                MessageBox.Show("请选择一项，点击删除");
            }
            else
            {
                string str = "select * from Goods where Supplier_id='" + goods_id + "'";
                //string str = "select * from category where Classification_id='" + goods_id + "'";
               // string str1 = "select * from category where Classification_id'" + goods_id + "'";
               // string str2 = "select * from Storehouse where Storehouse_id='" + goods_id + "'";
                //datatable dt1 = db.getdataset(str1);
                //datatable dt2 = db.getdataset(str2);

                DataTable dt = DB.GetDataSet(str);

               
                //if(dt.Rows.Count > 0||dt1.Rows.Count>0 || dt2.Rows.Count > 0)
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("不能删除此信息，请先");
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(index_id);

                    //添加日志
                    DataRow drlog = ds.Tables["log_info"].NewRow();//添加修改日志表
                    drlog["username"] = Login.username;
                    drlog["action_date"] = DateTime.Now;
                    drlog["action_table"] = "Goods表";
                    drlog["type"] = "删除";
                    drlog["log_main"] = "修改了Goods_id为 " + goods_id + "的订单";

                    ds.Tables["log_info"].Rows.Add(drlog);
                }
            }
        }

        private void btnreback_Click(object sender, EventArgs e)//撤销1
        {
            ds.RejectChanges();
            goods_id = "";
        }

        private void btnsave_Click(object sender, EventArgs e)//保存1
        {
            try
            {
                SqlCommandBuilder dbGoods = new SqlCommandBuilder(daGoods);//创建命令构造器
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);//创建命令构造器

                daGoods.Update(ds, "goods_info");
                daLog.Update(ds, "log_info");

                MessageBox.Show("删除成功");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DB.cn.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Goods_Load(object sender, EventArgs e)
        {
            linkLabel2.Text = Login.username;
            init();
            showAll();
            dgvHead();
            showXz();
           
        }

      
    }
}
