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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static bool flag = false;
        public static bool flag2 = false;
        public static string username;

        private void button1_Click(object sender, EventArgs e)//登录
        {
             if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入用户名或密码");
            }
            else
            {
                DB.Getcn();
                if (radioButton1.Checked)
                {
                    string str = "select * from Users  where username='"
                        + textBox1.Text + "' and pwd='" + textBox2.Text + "'and keys=1";
                    DataTable dt = DB.GetDataSet(str);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("登陆成功");
                        flag = true;
                        
                        username = textBox1.Text;
                        this.Close();
                        Default d1 = new Default();
                        d1.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                }
                else
                {

                    string str = "select * from Users  where username='"
                        + textBox1.Text + "' and pwd='" + textBox2.Text + "'and keys=2"; 
                    DataTable dt = DB.GetDataSet(str);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("登陆成功");
                        username = textBox1.Text;
                        flag = true;
                        this.Close();
                        administrator.index i1 = new administrator.index();
                        i1.Show(); 
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
