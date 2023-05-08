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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Data.Common;

namespace sale.administrator
{
    public partial class Sell_order : Form
    {
        public Sell_order()
        {
            InitializeComponent();
        }
        SqlDataAdapter daLog, daSell_order;
        DataSet ds = new DataSet();

        void init()//初始化函数
        {
            DB.Getcn();
            string str = "select * from Sell_order";
            string slr = "select * from log";

            daSell_order = new SqlDataAdapter(str, DB.cn);
            daLog =new SqlDataAdapter(slr, DB.cn);

            daLog.Fill(ds, "log_info");
            daSell_order.Fill(ds, "sell_info");
            DB.cn.Close();
        }

        void showAll()//显示全部
        {
            DataView dvSell_order = new DataView(ds.Tables["sell_info"]);
            dataGridView1.DataSource = dvSell_order;
        }

        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "订单编号";
            this.dataGridView1.Columns[1].HeaderText = "员工编号";
            this.dataGridView1.Columns[2].HeaderText = "商品编号";
            this.dataGridView1.Columns[3].HeaderText = "销售数量";
            this.dataGridView1.Columns[4].HeaderText = "顾客编号";

            this.dataGridView1.Columns[5].HeaderText = "运输编号";
            this.dataGridView1.Columns[6].HeaderText = "打折";
            this.dataGridView1.Columns[7].HeaderText = "订单日期";
            this.dataGridView1.Columns[8].HeaderText = "发送日期";
            this.dataGridView1.Columns[9].HeaderText = "到达日期";
            this.dataGridView1.Columns[10].HeaderText = "花费";
            this.dataGridView1.Columns[11].HeaderText = "千克";
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
            //点多了的响应事件
        }

        private void btnAdd_Click(object sender, EventArgs e)//添加1
        {
            if(text_Order_id.Text=="" || text_Order_num.Text=="" ||text_customers_id.Text==""||textBox_cost.Text==""
            ||comboBox__Employee_id.Items.Count == 0 || comboBox_Goods_id.Items.Count == 0)
            {
                MessageBox.Show("带*号的必须是必填项，不能为空");
            }
            else
            {
                string str = "select * from Sell_order where Order_id='" + text_Order_id.Text + "'";
                DataTable dt =DB.GetDataSet(str);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("该订单编号已存在，请重新输入");
                }
                else
                {
                    DataRow drSo = ds.Tables["sell_info"].NewRow();//创建行对象
                    drSo["Order_id"]=text_Order_id.Text;
                    //drSo["Employee_id"] = comboBox__Employee_id.Items.Count;//报错
                    drSo["Employee_id"] = comboBox__Employee_id.Text;
                    drSo["Goods_id"]=comboBox_Goods_id.Text;
                    drSo["Order_num"]=text_Order_num.Text;
                    drSo["customers_id"] = text_customers_id.Text;
                    drSo["Transporter_id"]=text_Transporter_id.Text;
                    drSo["Discount"]=textBox_Discount.Text;
                    drSo["Order_date"]=dateTimePicker_Order_date.Text;
                    drSo["Send_date"]=dateTimePicker_Send_date.Text;
                    drSo["Ariver_date"] = dateTimePicker_Ariver_date.Text;
                    drSo["cost"] =textBox_cost.Text;
                    drSo["kg"]=textBox_kg.Text;

                    ds.Tables["sell_info"].Rows.Add(drSo);




                    //添加日志表
                    DataRow drLog = ds.Tables["log_info"].NewRow();
                    drLog["username"] = Login.username;
                    drLog["type"] = "添加";
                    drLog["action_date"] = DateTime.Now;
                    drLog["action_table"] = "Sell_order表";
                    drLog["log_main"] = "修改了Order_id为" + text_Order_id.Text + "的订单";
                    ds.Tables["log_info"].Rows.Add(drLog);
                }
            }
               
            
        }

        private void btnReset_Click(object sender, EventArgs e)//重置1
        {
            text_Order_id.Text="";
            
            
            text_Order_num.Text="";
            text_customers_id.Text="";
            text_Transporter_id.Text = "";
            textBox_Discount.Text="";
            
            
           
            textBox_cost.Text="";
            textBox_kg.Text="";
        }

        private void btnRoback_Click(object sender, EventArgs e)//撤销1、、
        {
            ds.RejectChanges();
        }

        private void btnDel_Click(object sender, EventArgs e)//删除1
        {

        }

        private void btnSave_Click(object sender, EventArgs e)//保存1
        {
            try
            {
                SqlCommandBuilder dbSell_order = new SqlCommandBuilder(daSell_order);//创建命令构造器
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);//创建命令构造器

                daSell_order.Update(ds, "sell_info");
                daLog.Update(ds, "log_info");

                MessageBox.Show("添加成功");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DB.cn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)//修改
        {
            if (text_customers_id2.Text == "")
            {
                MessageBox.Show("顾客编号不能为空");
               
            }  if(textBox_Discount2.Text == "")
                {
                    MessageBox.Show("打折不能为空");
                }
            else
            {
                DataRow[] DeRows = ds.Tables["sell_info"].Select("Order_id='" +
                      dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'");

                //DeRows[0]["Department_name"] = text_department_name2.Text;
                //DeRows[0]["Manager_id"] = text_Manager_id2.Text;
                //DeRows[0]["Department_description"] = text_Department_description2.Text;
                //DeRows[0]["Manager"] = text_Manager2.Text;
                //DeRows[0]["Telephone"] = text_Telephone2.Text;

                DeRows[0]["Order_id"] = text_Order_id2.Text;
                //DeRows[0]["Employee_id"] = comboBox__Employee_id2.Items.Count;
                DeRows[0]["Employee_id"] = comboBox__Employee_id2.Text;
                //DeRows[0]["Goods_id"] = comboBox_Goods_id2.Items.Count;
                DeRows[0]["Goods_id"] = comboBox_Goods_id2.Text;
                DeRows[0]["Order_num"] = text_Order_num2.Text;
                DeRows[0]["customers_id"] = text_customers_id2.Text;
                DeRows[0]["Transporter_id"] = text_Transporter_id2.Text;
                DeRows[0]["Discount"] = textBox_Discount2.Text;
                DeRows[0]["Order_date"] = dateTimePicker_Order_date2.Text;
                DeRows[0]["Send_date"] = dateTimePicker_Send_date2.Text;
                DeRows[0]["Ariver_date"] = dateTimePicker_Ariver_date2.Text;
                DeRows[0]["cost"] = textBox_cost2.Text;
                DeRows[0]["kg"] = textBox_kg2.Text;


                DataRow drlog = ds.Tables["log_info"].NewRow();//添加修改日志表
                drlog["username"] = Login.username;
                drlog["action_date"] = DateTime.Now;
                drlog["action_table"] = "Sell_order表";
                drlog["type"] = "修改";
                drlog["log_main"] = "修改了Order_id为 "+ text_Order_id2.Text + "的订单";

                ds.Tables["log_info"].Rows.Add(drlog);

            }
        }

        private void btnRoback2_Click(object sender, EventArgs e)//撤销2·
        {
            ds.RejectChanges();
        }

        private void btnDel2_Click(object sender, EventArgs e)//删除2
        {

        }

        private void btnSave2_Click(object sender, EventArgs e)//保存2
        {
            try
            {
                SqlCommandBuilder dbSell_order = new SqlCommandBuilder(daSell_order);
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);
                daSell_order.Update(ds, "sell_info");
                daLog.Update(ds, "log_info");
                MessageBox.Show("修改成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)//多选转单选
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//所有列自适应
            if (dataGridView1.Rows.Count > 0)
            {
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
                //修改的加的下面是
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if(_selectValue == "True"){
                        text_Order_id2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        
                        comboBox__Employee_id2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        comboBox_Goods_id2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        text_Order_num2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        text_customers_id2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        text_Transporter_id2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        textBox_Discount2.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        dateTimePicker_Order_date2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        dateTimePicker_Send_date2.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        dateTimePicker_Ariver_date2.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        textBox_cost2.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        textBox_kg2.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        
                    }
                }
            }
        }
        private void Sell_order_Load(object sender, EventArgs e)//窗体响应事件加载
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet3.Goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.海产品管理系统DataSet3.Goods);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet2.Employee”中。您可以根据需要移动或移除它。
            this.employeeTableAdapter.Fill(this.海产品管理系统DataSet2.Employee);


            label2.Text = Login.username;
            init();
            showAll();
            dgvHead();
            showXz();
            label2.Text = Login.username;
        }
    }
}
