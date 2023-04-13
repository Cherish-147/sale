using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale
{
    internal class DB
    {
        public static SqlConnection cn;
        public static SqlConnection Getcn()
        {
            string mystr = "server=.;database=海产品管理系统;integrated security=true";
            if (cn == null || cn.State == ConnectionState.Closed)
            {
                cn = new SqlConnection(mystr);
                cn.Open();
            }
            return cn;
        }
        public static DataTable GetDataSet(string sql)//查询数据库
        {
            SqlCommand cmd = new SqlCommand(sql, cn);//执行SQL语句
            SqlDataAdapter da = new SqlDataAdapter(cmd);//将执行结果保存到适配器中·
            DataSet ds = new DataSet();//创建数据集
            da.Fill(ds);//适配器填充到数据集中
            return ds.Tables[0];
        }
        public static Boolean sqlEx(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show("执行失败" + ex.Message.ToString());
                return false;
            }return true;
        }
    }
}
