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
    public partial class CHpwd : Form
    {
        public CHpwd()
        {
            InitializeComponent();
        }

        private void CHpwd_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.Getcn();
            string str = "select * from Users where username='" + textBox1.Text + "' and pwd='" + textBox2.Text + "'";
            string sdr = "update username set pwd='" + textBox3.Text + "' where username='" + textBox1.Text + "'";
            if (textBox2.Text=="")
            {
                MessageBox.Show("请输入原密码：");
            }
            else
            {
                DataTable dt = DB.GetDataSet(str);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("原密码错误，请重新输入");
                }
                else
                {
                    if (textBox3.Text == "" || textBox4.Text ==  "")
                    {
                        MessageBox.Show("请输入密码：");

                    }
                    else
                    {
                        if (textBox3.Text != textBox4.Text)
                        {
                            MessageBox.Show("请重新输入密码");
                        }
                        else
                        {
                            if (textBox3.Text!= textBox4.Text)
                            {
                                MessageBox.Show("两次密码不一致");

                            }
                            else
                            {
                                DB.sqlEx(str);
                                MessageBox.Show("修改成功");
                                 
                            }
                        }
                    }
                }
            }
        }
    }
}
