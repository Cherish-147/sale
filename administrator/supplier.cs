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
    public partial class supplier : Form
    {
        public supplier()
        {
            InitializeComponent();
        }

        SqlDataAdapter daLog, daSupplier;
        DataSet ds = new DataSet();
        public static string supplier_id = "";
        public static int index_id;

        void init()//初始化函数
        {
            DB.Getcn();
            string str = "select * from Supplier";
            string slr = "select * from log";

            daSupplier = new SqlDataAdapter(str, DB.cn);
            daLog = new SqlDataAdapter(slr, DB.cn);

            daLog.Fill(ds, "log_info");
            daSupplier.Fill(ds, "supplier_info");
            DB.cn.Close();
        }

        void showAll()//显示全部
        {
            DataView dvSupplier = new DataView(ds.Tables["supplier_info"]);
            dataGridView1.DataSource = dvSupplier;
        }

        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "供应商编号";
            this.dataGridView1.Columns[1].HeaderText = "供应商姓名";
            this.dataGridView1.Columns[2].HeaderText = "联络人";
            this.dataGridView1.Columns[3].HeaderText = "电话";


        }

        void showXz()//显示选择列
        {
            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);
        }
        private void btndel_Click(object sender, EventArgs e)//删除
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString() == "True")
                {
                    supplier_id = dataGridView1.Rows[i].Cells["Supplier_id"].Value.ToString();
                    index_id = i;
                }
            }
            if (supplier_id == "")
            {
                MessageBox.Show("请选择一项，再点击删除");
            }
            else
            {
                string str = "select * from Goods where Supplier_id='" + supplier_id + "'";
                DataTable dt = DB.GetDataSet(str);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("不能删除此信息，请先删除产品表的相关信息");
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(index_id);

                    //添加日志
                    DataRow drlog = ds.Tables["log_info"].NewRow();//添加修改日志表
                    drlog["username"] = Login.username;
                    drlog["action_date"] = DateTime.Now;
                    drlog["action_table"] = "Supplier表";
                    drlog["type"] = "删除";
                    drlog["log_main"] = "修改了supplier_id为 " + supplier_id + "的订单";

                    ds.Tables["log_info"].Rows.Add(drlog);
                }
            }
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            linkLabel2.Text = Login.username;
            init();
            showAll();
            dgvHead();
            showXz();
        }

        private void btnreback_Click(object sender, EventArgs e)//撤销
        {
            ds.RejectChanges();
            supplier_id = "";
        }

        private void btnsave_Click(object sender, EventArgs e)//保存1
        {
            try
            {
                SqlCommandBuilder dbSupplier = new SqlCommandBuilder(daSupplier);//创建命令构造器
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);//创建命令构造器

                daSupplier.Update(ds, "supplier_info");
                daLog.Update(ds, "log_info");

                MessageBox.Show("删除成功");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DB.cn.Close();
        
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
            }
        }
    }
}
