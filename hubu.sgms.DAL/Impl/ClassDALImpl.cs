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
    public class ClassDALImpl : IClassDAL
    {


        public IList<Class> SelClassByMajorId(string MajorId)
        {
            string sql = "select class_id,substring(class_id,5,4) class_name from class where major_id=@majorid ";
            SqlParameter[] pars = {
                new SqlParameter("@majorid",MajorId),

        };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<Class> classList = new List<Class>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Class c = new Class();
                c.class_id = dataTable.Rows[i]["class_id"].ToString();
                c.yuliu1 = dataTable.Rows[i]["class_name"].ToString();
                classList.Add(c);
            }
            return classList;
        }

        public Class SelClassByClassId(string ClassId)
        {
            string sql = "select yuliu1 from Class where Class_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",ClassId),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            Class c = null;


            if (dataTable.Rows.Count > 0)
            {
                c = new Class();
                DataRow dataRow = dataTable.Rows[0];

                c.yuliu1 = dataRow["yuliu1"].ToString();

            }

            return c;
        }
    }
}
