
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
    public class MajorDALImpl:IMajorDAL
    {
        

        public IList<Major> SelMajorByCollegeId(string CollegeId)
        {
            string sql = "select major_id,major_name from major where college_id=@collegeid ";
            SqlParameter[] pars = {
                new SqlParameter("@collegeid",CollegeId),
                
             };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql,pars);

            IList<Major> majorList = new List<Major>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Major m = new Major();
                m.major_id = dataTable.Rows[i]["major_id"].ToString();
                m.major_name = dataTable.Rows[i]["major_name"].ToString();
                majorList.Add(m);
            }
            return majorList;
        }

       public  Major SelMajorByMajorId(string MajorId)
        {
            string sql = "select major_name from major where major_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",MajorId),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

           Major m = null;


            if (dataTable.Rows.Count > 0)
            {
                m = new Major();
                DataRow dataRow = dataTable.Rows[0];

                m.major_name = dataRow["major_name"].ToString();

            }

            return m;
        }

    }
}
