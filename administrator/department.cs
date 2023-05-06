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
    public partial class department : Form
    {
        public department()
        {
            InitializeComponent();
        }

        SqlDataAdapter daLog, daDepartment;
        DataSet ds = new DataSet();

        void init()//初始化函数
        {
            DB.Getcn();
            string str = "select * from Department";
            string slr = "select * from log";

            daLog = new SqlDataAdapter(slr, DB.cn);
            daDepartment = new SqlDataAdapter(str, DB.cn);

            daLog.Fill(ds, "log_info");
            daDepartment.Fill(ds, "department_info");
            DB.cn.Close();
        }

        void showAll()//显示全部
        {
            DataView dvDepartment = new DataView(ds.Tables["department_info"]);
            dataGridView1.DataSource = dvDepartment;
        }

        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "部门编号";
            this.dataGridView1.Columns[1].HeaderText = "部门名";
            this.dataGridView1.Columns[2].HeaderText = "管理者编号";
            this.dataGridView1.Columns[3].HeaderText = "部门描述";
            this.dataGridView1.Columns[4].HeaderText = "管理者名";
            
            this.dataGridView1.Columns[5].HeaderText = "电话";
            
            


        }
        void showXz()//显示选择列
        {
            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//多选转单选
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//所有列自适应

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dataGridView1.Rows[i].Cells["acCode"] as DataGridViewCheckBoxCell;

                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//所有列自适应
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
                        text_department_id2.Text          = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        text_department_name2.Text        = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        text_Manager_id2.Text             = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        text_Department_description2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        text_Manager2.Text                = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        text_Telephone2.Text              = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    }
                }
            }
            }

        private void btnAdd_Click(object sender, EventArgs e)//添加
        {
            if(text_department_id.Text == "" || text_department_name.Text == "")
            {
                MessageBox.Show("带*号的必须是必填项，不能为空");
            }
            else
            {
                DB.Getcn();
                string str = "select * from Department where Department_id='" + text_department_id.Text + "'";
                DataTable dt = DB.GetDataSet(str);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("该部门编号已存在，请重新输入");
                }
                else
                {
                    DataRow drDe = ds.Tables["department_info"].NewRow();//创建行对象
                    drDe["department_id"] = text_department_id.Text;
                    drDe["department_name"] = text_department_name.Text;
                    drDe["Manager_id"] = text_Manager_id.Text;
                    drDe["Department_description"] = text_Department_description.Text;
                    drDe["Manager"] = text_Manager.Text;
                    drDe["Telephone"] = text_Telephone.Text;
                    
                    ds.Tables["department_info"].Rows.Add(drDe);


                    //添加日志表
                    DataRow drLog = ds.Tables["log_info"].NewRow();
                    drLog["username"] = Login.username;
                    drLog["type"] = "添加";
                    drLog["action_date"] = DateTime.Now;
                    drLog["action_table"] = "Department表";
                    drLog["log_main"] = "修改了Department_id为" + text_department_id.Text + "的部门";
                    ds.Tables["log_info"].Rows.Add(drLog);
                }
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)//重置
        {
            text_department_id.Text = "";
            text_department_name.Text = "";
            text_Manager_id.Text = "";
            text_Department_description.Text = "";
            text_Manager.Text = "";
            text_Telephone.Text = "";
        }

        private void btnRoback_Click(object sender, EventArgs e)//撤销
        {
            ds.RejectChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)//保存
        {
            try
            {
                SqlCommandBuilder dbDepartment = new SqlCommandBuilder(daDepartment);//创建命令构造器
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);//创建命令构造器

                daDepartment.Update(ds, "department_info");
                daLog.Update(ds, "log_info");

                MessageBox.Show("添加成功");

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DB.cn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)//修改
        {
            if (text_department_name2.Text =="")
            {
                MessageBox.Show("部门名不能为空");
            }
            else
            {
                DataRow[] DeRows = ds.Tables["department_info"].Select("Department_id='" +
                      dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'");

                DeRows[0]["Department_name"]=text_department_name2.Text;
                DeRows[0]["Manager_id"] = text_Manager_id2.Text;
                DeRows[0]["Department_description"] = text_Department_description2.Text;
                DeRows[0]["Manager"] = text_Manager2.Text;
                DeRows[0]["Telephone"] = text_Telephone2.Text;


                DataRow drlog = ds.Tables["log_info"].NewRow();//添加日志表2
                drlog["username"] = Login.username;
                drlog["action_date"] = DateTime.Now;
                drlog["action_table"] = "Department表";
                drlog["type"] = "修改";
                drlog["log_main"] = "修改了Department_id为" + text_department_id2.Text + "的部门";
                
                ds.Tables["log_info"].Rows.Add(drlog);
            }
        }

        private void btnRoback2_Click(object sender, EventArgs e)//撤销2
        {
            ds.RejectChanges();
        }

        private void btnSave2_Click(object sender, EventArgs e)//保存2
        {
            try
            {
                SqlCommandBuilder dbDepartment = new SqlCommandBuilder(daDepartment);
                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);
                daDepartment.Update(ds, "department_info");
                daLog.Update(ds, "log_info");
                MessageBox.Show("修改成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void department_Load(object sender, EventArgs e)//窗体响应时间加载
        {
            label2.Text = Login.username;
            init();
            showAll();
            dgvHead();
            showXz();
            label2.Text = Login.username;
        }
    }
}
