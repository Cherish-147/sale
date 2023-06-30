using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Data.SqlClient;

namespace sale.administrator
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        
        saleDataContext db = new saleDataContext();
        //public static int Goods_id11;
        public static int Goods_id11;
        public static string f_name;
        protected void Bind()//刷新
        {
            var results = from r in db.Goods
                          select r;
            dataGridView1.DataSource = results;
        }
        private void product_Load(object sender, EventArgs e)//窗体加载
        {
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet11.category”中。您可以根据需要移动或移除它。
            this.categoryTableAdapter3.Fill(this.海产品管理系统DataSet11.category);
            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet7.category”中。您可以根据需要移动或移除它。
            this.categoryTableAdapter2.Fill(this.海产品管理系统DataSet7.category);

            // TODO: 这行代码将数据加载到表“海产品管理系统DataSet5.Supplier”中。您可以根据需要移动或移除它。
            this.supplierTableAdapter.Fill(this.海产品管理系统DataSet5.Supplier);

            linkLabel1.Text = Login.username;//当前用户名

            Bind();
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 240;
           //dataGridView1多出三列数据库没有的列

        }

        private void button1_Click(object sender, EventArgs e)//选择一张图片
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)//添加
        {
            //string fileName;
            //string fileFolder;
            //string fileSaveFolder;
            //string dateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            //fileName = Path.GetFileName(pictureBox1.ImageLocation);
            //fileName = dateTime + fileName;

            //fileFolder = Application.StartupPath + "\\自己保存地址的名称\\" + class_id.Text + "\\";
            //fileFolder = Application.StartupPath + "\\Goods_Images\\" + class_id.Text + "\\";
            //fileSaveFolder = fileFolder + fileName;

            string fileName;
            string filefolder;
            string fileSaveFolder;
            string dateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            fileName = Path.GetFileName(pictureBox1.ImageLocation);
            fileName = dateTime + fileName;

            filefolder = Application.StartupPath + "\\Goods_Images\\" +
                class_id.Text + "\\";
            fileSaveFolder = filefolder + fileName;

            Goods g = new Goods();
            g.Goods_id = int.Parse(text_id.Text);
            g.Goods_name = text_name.Text;
            //g.Unit_price = decimal.Parse(text_listPrice.Text);
            g.Unit_price = int.Parse(text_listPrice.Text);
            g.Classification_id= int.Parse(class_id.SelectedValue.ToString());
            g.Supplier_id = int.Parse(comboBox_supid.SelectedValue.ToString());
            //g.Supplier_id = int.Parse(comboBox_sup.SelectedValue.ToString());
            g.Stock_quantity = int.Parse(text_qty.Text);
            if (pictureBox1.Image != null)
            {
                g.img = fileSaveFolder;
            }
            else
            {
                g.img = null;
            }
            //if (picturebox1.image != null)
            //{
            //    image image = picturebox1.image;
            //    image.save(filesavefolder);
            //}

            db.Goods.InsertOnSubmit(g);
            db.SubmitChanges();
            Bind();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(fileSaveFolder);
            }
            //添加日志
            log v = new log();
            v.username = Login.username;
            v.type = "添加";
            v.action_date = DateTime.Now;
            v.action_table = "Goods表";
            v.log_main = "添加了Goods_id为 " + Goods_id11 + "的订单";

            db.log.InsertOnSubmit(v);

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//单机列表
        {
            int n = dataGridView1.CurrentRow.Index;
            Goods_id11 = int.Parse(dataGridView1.Rows[n].Cells["Goods_id"].Value.ToString());
            DB.Getcn();
           // string str = "select Classifcation_name from category where Classification_id='"
              //  + dataGridView1.Rows[n].Cells["Classification_id"].Value.ToString() + "'"; 
            //上面代码找不到列
            string str = "select Classifcation_name from category where class_id='"
                + dataGridView1.Rows[n].Cells["class_id"].Value.ToString() + "'";

            //MessageBox.Show(str);
            DataTable dt = DB.GetDataSet(str);
            if (dt.Rows.Count > 0)
            {
                class_id.Text = dt.Rows[0][0].ToString();
            }
            string sdr = "Select supplier_name from Supplier where Supplier_id='"
              + dataGridView1.Rows[n].Cells["Supplier_id"].Value.ToString() + "'";


            //string str = "select Classifcation_name from category where Classifcation_id='"
            //    + int.Parse(dataGridView1.Rows[n].Cells["Classifcation_id"].Value.ToString()) + "'";
            //DataTable dt = DB.GetDataSet(str);
            //if (dt.Rows.Count > 0)
            //{
            //    class_id.Text = dt.Rows[0][0].ToString();
            //}
            //string sdr = "select Supplier_name from supplier where Supplier_id='"
            //    + int.Parse(dataGridView1.Rows[n].Cells["Supplier_id"].Value.ToString()) + "'";
            DataTable dn = DB.GetDataSet(sdr);
            if (dn.Rows.Count > 0)
            {
                comboBox_supid.Text = dn.Rows[0][0].ToString();
            }
            text_id1.Text = dataGridView1.Rows[n].Cells["Goods_id"].Value.ToString();
            //text_listPrice.Text = dataGridView1.Rows[n].Cells["ListPrice"].Value.ToString();

            text_listprice1.Text = dataGridView1.Rows[n].Cells["Unit_price"].Value.ToString();
            text_name1.Text = dataGridView1.Rows[n].Cells["Goods_name"].Value.ToString();
            textBox_qty1.Text = dataGridView1.Rows[n].Cells["Stock_quantity"].Value.ToString();
            //textBox5.Text = dataGridView1.Rows[n].Cells["descn"].Value.ToString();

            f_name = dataGridView1.Rows[n].Cells["img"].Value.ToString();

            pictureBox2.Load(f_name);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void change_pic_Click(object sender, EventArgs e)//换一张图片
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Load(opendialog.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void btn_reset_Click(object sender, EventArgs e)//修改
        {
            string fileName;
            string fileFolder;
            string fileSaveFolder;
            string dateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            fileName = Path.GetFileName(pictureBox2.ImageLocation);
            fileName = dateTime + fileName;

            fileFolder = Application.StartupPath + "\\Goods_Images\\" + combox_class1.Text + "\\";
            fileSaveFolder = fileFolder + fileName;

            var results = from r in db.Goods
                          where r.Goods_id == Goods_id11
                          select r;
            if (results != null)
            {
                foreach (Goods r in results)
                {
                   // r.Classification_id= int.Parse(combox_class1.SelectedValue.ToString()); 
                    //r.ListPrice = decimal.Parse(textBox1.Text);
                    r.Unit_price = decimal.Parse(text_listprice1.Text);
                    r.Supplier_id = int.Parse(comboBox_sup1.SelectedValue.ToString());
                    r.Goods_name = text_name1.Text;
                    r.Stock_quantity = int.Parse(textBox_qty1.Text);
                    //r.Descn = textBox5.Text;
                    r.img = fileSaveFolder;
                   
                }
            }
            db.SubmitChanges();
            Bind();
            if (pictureBox2.Image != null)
            {
                Image image = pictureBox2.Image;
                image.Save(fileSaveFolder);
            }
            //添加日志

            log v = new log();
            v.username = Login.username;
            v.type = "修改";
            v.action_date = DateTime.Now;
            v.action_table = "Goods表";
            v.log_main = "修改了Goods_id为 " + Goods_id11 + "的订单";

            db.log.InsertOnSubmit(v);
        }
    }
}
