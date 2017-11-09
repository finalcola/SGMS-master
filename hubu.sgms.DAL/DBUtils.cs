using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace hubu.sgms.DAL
{
    public class DBUtils
    {
        private string connstring = null;
        private SqlConnection conn = null;
        private SqlCommand comm;
        static private DBUtils dbUtils = null;

        private DBUtils()
        {
            //配置文件中提取
             connstring = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
             conn = new SqlConnection(connstring);
            //conn = new SqlConnection("uid=sa;pwd=19961219;database=flower");  
        }

        //获取DBUtils类对象
        public static DBUtils getDBUtils()
        {
            if(dbUtils == null)
            {
                dbUtils = new DBUtils();
            }
            return dbUtils;
        }

        //增删改操作
        public int cud(string sql, SqlParameter[] param)
        {
            conn.Open();
            comm = new SqlCommand(sql, conn);
            if (param.Length > 0)
            {
                foreach (SqlParameter sqlParameter in param)
                {
                    comm.Parameters.Add(sqlParameter);  //@占位符处参数替换
                }
            }
            int i = comm.ExecuteNonQuery();  //执行操作，不产生记录集
            conn.Close();
            return i;  //返回受到影响的行数                   
        }

        //增删改  无参  重载
        public int cud(string sql) 
        {
            return cud(sql, new SqlParameter[] { });
        }


        //查询操作
        public DataTable getRecords(string sql, SqlParameter[] param)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            // SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            if (param.Length > 0)
            {
                foreach (SqlParameter sqlParameter in param)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            DataTable dataTable = new DataTable();
            if(sqlDataAdapter != null)
            {
                sqlDataAdapter.Fill(dataTable);   //将查询结果填充
            }           
            conn.Close();
            return dataTable;   //返回内存中的数据表(虚拟表)
        }



        //查询操作 无参 重载
        public DataTable getRecords(string sql)
        {
            return getRecords(sql, new SqlParameter[] { });
        }

        //分页查询 
        public DataTable getRecordsWithPage(string sql, SqlParameter[] param, int pageSize, int page) 
        {
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            if (param.Length > 0)
            {
                foreach (SqlParameter sqlParameter in param)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill((page - 1) * pageSize, pageSize, dataTable);   //选择性填充
            conn.Close();
            return dataTable;
        }

        //分页查询 无参 重载
        public DataTable getRecordsWithPage(string sql, int pageSize, int page)
        {
            return getRecordsWithPage(sql, new SqlParameter[] { }, pageSize, page);
        }
    }
}
