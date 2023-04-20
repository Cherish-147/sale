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

namespace sale.administrator
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        SqlDataAdapter daEmployee;
        DataSet ds =new DataSet();

        void init()
        {
            DB.Getcn();
            string str = "select * from Employee";
            daEmployee = new SqlDataAdapter(str, DB.cn);
            daEmployee.Fill(ds,"employee_info");
            DB.cn.Close();
        }
        void showAll()
        {
            DataView dvEmployee = new DataView(ds.Tables["employee_info"]);
            dataGridView1.DataSource= dvEmployee;
        }
        void dgvHead()
        {
            this.dataGridView1.Columns[0].HeaderText = "员工编号";
            this.dataGridView1.Columns[1].HeaderText = "员工姓名";
            this.dataGridView1.Columns[2].HeaderText = "性别";
            this.dataGridView1.Columns[3].HeaderText = "生日";
            this.dataGridView1.Columns[4].HeaderText = "雇佣日期";
            this.dataGridView1.Columns[5].HeaderText = "地址";
            this.dataGridView1.Columns[6].HeaderText = "电话";
            this.dataGridView1.Columns[7].HeaderText = "工资";
            //this.dataGridView1.Columns[8].HeaderText = "部门编号";
            

        }
        void showXz()
        {
            DataGridViewCheckBoxColumn acCode =new DataGridViewCheckBoxColumn();
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
            init();
            showAll();
            dgvHead();
            showXz();
            lbluser.Text =Login.username;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            }
        }
    }
   
}
 