using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)//注册
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入用户名或密码");

            }
            else
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次密码不一致，请重新输入");
                }
                else
                {
                    DB.Getcn();
                    string str = "select * from Users where username='" + textBox1.Text + "'";
                    DataTable dt = DB.GetDataSet(str);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("已存在");

                    }
                    else
                    {
                        string sdr = "insert into Users values('" + textBox1.Text + "','" + textBox2.Text + "',1)";//1是用户
                        DB.sqlEx(sdr);
                        MessageBox.Show("注册成功");

                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }
    }
}
