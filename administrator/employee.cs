﻿using System;
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

namespace sale.administrator
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        SqlDataAdapter daEmployee,daLog,daDepartment;
        
        DataSet ds = new DataSet();

        void init()//初始化函数
        {
            DB.Getcn();
            string str = "select * from Employee";
            string slr = "select * from log";
            string spr = "select * from Department";
            daEmployee = new SqlDataAdapter(str, DB.cn);
            daLog = new SqlDataAdapter(slr, DB.cn);
            daDepartment = new SqlDataAdapter(spr, DB.cn);
            
            daEmployee.Fill(ds, "employee_info");
            daLog.Fill(ds, "log_info");
            daDepartment.Fill(ds, "department_info");
            DB.cn.Close();
        }
        void showAll()//显示全部
        {
            DataView dvEmployee = new DataView(ds.Tables["employee_info"]);
            dataGridView1.DataSource = dvEmployee;
        }
        void dgvHead()//重绘表头
        {
            this.dataGridView1.Columns[0].HeaderText = "员工编号";
            this.dataGridView1.Columns[1].HeaderText = "员工姓名";
            this.dataGridView1.Columns[2].HeaderText = "性别";
            this.dataGridView1.Columns[3].HeaderText = "生日";
            this.dataGridView1.Columns[4].HeaderText = "雇佣日期";
            this.dataGridView1.Columns[5].HeaderText = "地址";
            this.dataGridView1.Columns[6].HeaderText = "电话";
            this.dataGridView1.Columns[7].HeaderText = "工资";
            this.dataGridView1.Columns[9].HeaderText = "简介";
            //this.dataGridView1.Columns[8].HeaderText = "部门编号";


        }
        void showXz()//显示选择列
        {
            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);
        }
        private void employee_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet1.Department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter1.Fill(this.海产品管理系统DataSet1.Department);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet.Department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.海产品管理系统DataSet.Department);
            lbluser.Text = Login.username; 
            init();
            showAll();
            dgvHead();
            showXz();
            lbluser.Text = Login.username;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//多选转单选
        {
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
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string _selectValue = dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        text_id2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        text_name2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        combo_sex2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        dateTimePicker3.Value=Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value.ToString()); 
                        dateTimePicker4.Value=Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value.ToString()); 
                        text_address2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        text_phone2.Text= dataGridView1.Rows[i].Cells[6].Value.ToString();
                        text_wages2.Text= dataGridView1.Rows[i].Cells[7].Value.ToString();



                        DataRow[] daDepartment = ds.Tables["department_info"].Select("Department_id='" 
                            + dataGridView1.Rows[i].Cells[8].Value.ToString() + "'");





                        //DataRow[] daDepartment = ds.Tables["department_info"].Select("Department_id='"
                        //    + dataGridView1.Rows[i].Cells[8].Value.ToString() + "'");

                        //combo_department2.Text = drDep[0]["department_name"].ToString();

                        text_resume2.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)//添加
        {
            if (text_id.Text == "" || text_name.Text == "" || text_phone.Text == "")
            {
                MessageBox.Show("带*号的必须是必填项，不能为空");

            }
            if(text_wages.Text == "" || text_wages.Text == "^-?\\d+(\\.\\d+)?$\r\n")//还不会捕获wages不是整数的异常
            {
                
                //CTRL + k,c 注释选中行
                //CTRL + k,u 取消对选中行的注释

                //try
                //{   Boolean flag = true;
                //    // your code that may generate the FormatException
                //}
                //catch (FormatException ex)
                //{
                //    Console.WriteLine("FormatException: " + ex.Message);
                //}
                MessageBox.Show("Wages输入字符串的格式不正确,请输入整型数数字");
                MessageBox.Show("Wages不能为空字符串");
            }
            else
            {
                if (DateTime.Today.Year - dateTimePicker1.Value.Year < 18)
                {
                    MessageBox.Show("员工年龄不能小于18岁");
                }
                else
                {
                    DB.Getcn();
                    string str = "select * from Employee where Employee_id='" + text_id.Text + "'";
                    DataTable dt = DB.GetDataSet(str);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("该员工编号已存在，请重新输入");
                    }
                    else
                    {
                        DataRow drEm = ds.Tables["employee_info"].NewRow();//创建行对象
                        drEm["Employee_id"] = text_id.Text;
                        drEm["Employee_name"] = text_name.Text;
                        drEm["Sex"] = combo_sex.Text;
                        drEm["Birth_date"] = dateTimePicker1.Value;
                        drEm["Hire_date"] = dateTimePicker2.Value;
                        drEm["Address"] = text_address.Text;
                        drEm["Telephone"] = text_phone.Text;
                        drEm["Wages"] = int.Parse(text_wages.Text);
                        drEm["Department_id"] = combo_department.SelectedValue;
                        ds.Tables["employee_info"].Rows.Add(drEm);

                        //添加日志表
                        DataRow drLog = ds.Tables["log_info"].NewRow();
                        drLog["username"] = Login.username;
                        drLog["type"] = "添加";
                        drLog["action_date"] = DateTime.Now;
                        drLog["action_table"] = "Employee表";
                        drLog["log_main"] = "修改了Employee_id为" + text_id.Text + "的员工";
                        ds.Tables["log_info"].Rows.Add(drLog);



                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)//重置
        {
            text_id.Text = "";
            text_name.Text = "";
            text_address.Text = "";
            text_phone.Text = "";
            text_wages.Text = "";
            text_resume.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)//修改
        {
            if (DateTime.Today.Year - dateTimePicker3.Value.Year < 18)
            {
                MessageBox.Show("员工年龄不能小于18岁");
            }
            else
            {
                if (text_name2.Text == "")
                {
                    MessageBox.Show("员工姓名不能为空");

                }
                else
                {
                    DataRow[] EmRows = ds.Tables["employee_info"].Select("Employee_id='" +
                      dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()+"'");
                    EmRows[0]["Employee_name"]=text_name2.Text;
                    EmRows[0]["Sex"] = combo_sex2.Text;
                    EmRows[0]["Birth_date"] = dateTimePicker3.Value;
                    EmRows[0]["Hire_date"]=dateTimePicker4.Value;
                    EmRows[0]["Address"]=text_address2.Text;
                    EmRows[0]["Telephone"]=text_phone2.Text;
                    EmRows[0]["Wages"]=text_wages2.Text;
                    EmRows[0]["Department_id"]=combo_department2.Text;


                    DataRow drlog = ds.Tables["log_info"].NewRow();//添加日志表
                    drlog["username"] = Login.username;
                    drlog["action_date"] = DateTime.Now;
                    drlog["action_table"] = "Employee表";
                    drlog["type"] = "修改";
                    drlog["log_main"] = "修改了员工编号为" + text_id2.Text + "的员工";
                    ds.Tables["log_info"].Rows.Add(drlog);
                }
            }
        }

        private void btn_save2_Click(object sender, EventArgs e)//保存2
        {
            try
            {
                SqlCommandBuilder dbEmployee =new SqlCommandBuilder(daEmployee);
                SqlCommandBuilder dbLog =new SqlCommandBuilder(daLog);
                daEmployee.Update(ds, "employee_info");
                daLog.Update(ds, "log_info");
                MessageBox.Show("修改成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Reback2_Click(object sender, EventArgs e)//撤销2
        {
            ds.RejectChanges();
        }

        private void btnReback_Click(object sender, EventArgs e)//撤销
        {
            ds.RejectChanges();
        }

        private void btn_save_Click(object sender, EventArgs e)//保存添加
        {
            try
            {
                SqlCommandBuilder dbEmployee = new SqlCommandBuilder(daEmployee);//创建命令构造器

                SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);//少了这句 daLog.Update(ds,"log_info");会报错
                daEmployee.Update(ds, "employee_info");
                daLog.Update(ds,"log_info");
                MessageBox.Show("添加成功");


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DB.cn.Close();
        }
    }
}