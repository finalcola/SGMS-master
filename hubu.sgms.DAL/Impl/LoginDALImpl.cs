using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL.Impl
{
    public class LoginDALImpl : ILoginDAL
    {
        public Login GetUser(string username, string password)
        {
            string sql = "select * from login where username = @username and password = @password";

            SqlParameter[] pars = {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password)
            };

            //DataTable dataTable = SqlHelper.GetTable(sql,CommandType.Text,pars);
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);
            Login login = null;
            if (dataTable.Rows.Count > 0)
            {
                login = new Login();
                DataRow dataRow = dataTable.Rows[0];
                login.Id = Convert.ToInt32(dataRow["Id"]);
                login.username = dataRow["username"].ToString();
                login.password = dataRow["password"].ToString();
                login.role = dataRow["role"].ToString();
            }
            return login;
        }

        public void ChangePass(string username, string password)
        {
            string sql = "update Login set password=@password where username=@username";
            SqlParameter[] pars = {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password)
            };
            DBUtils.getDBUtils().cud(sql, pars);
        }
    }
}
