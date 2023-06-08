using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace sale
{
    public partial class Order1 : Form
    {
        saleDataContext db = new saleDataContext();
        public Order1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             //获取购物车内商品项目
            List<Cartltem> cartItemList = (from c in db.Cartltem
                                           where c.username == Login.username
                                           select c).ToList();

            //根据送货地址信息创建订单头，状态为“未审核”
            Orders order = new Orders();
            order.username = Login.username;
            order.province = state.Text;
            order.city = city.Text;
            order.order_time = DateTime.Now;
            order.address = Address.Text;
            order.zip = zip.Text;
            order.phone = Phone.Text;
            order.status = "未审核";

            //根据购物车商品清单创建订单明细   
            OrderItem orItem = null;
            foreach (Cartltem cartItem in cartItemList)
            {
                //依次添加每件商品为订单明细                
                orItem = new OrderItem();
                orItem.order_id = order.order_id;
                orItem.ProName = cartItem.ProName;
                orItem.ListPrice = (int)cartItem.ListPrice;
                orItem.Qty = (int)cartItem.Qty;
                orItem.totalprice =(int)(cartItem.Qty * cartItem.ListPrice);

                order.OrderItem.Add(orItem);
                //OrderItem.Add(orItem); 

                //从购物车中删除购物项
                db.Cartltem.DeleteOnSubmit(cartItem);
            }

            db.Orders.InsertOnSubmit(order);
            db.SubmitChanges();

            MessageBox.Show("订单已提交");
            this.Dispose();
            Default d1 = new Default();
            d1.ShowDialog();
        }
    }
}
