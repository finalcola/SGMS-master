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
    public class ClassroomDALImpl:IClassroomDAL
    {
        public IList<Classroom> SelClassroomByBuilding(string Building)
        {
            string sql = "select classroom_id,classroom from classroom where building=@building and status='1'";
            SqlParameter[] pars = {
                new SqlParameter("@building",Building),

             };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<Classroom> ClassroomList = new List<Classroom>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Classroom c = new Classroom();
                c.classroom_id = dataTable.Rows[i]["classroom_id"].ToString();
                c.classroom = dataTable.Rows[i]["classroom"].ToString();
                ClassroomList.Add(c);
            }
            return ClassroomList;
        }

        public Classroom SelClassroomByClassroomId(string ClassroomId)
        {
            string sql = "select classroom from classroom where classroom_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",ClassroomId),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            Classroom c = null;


            if (dataTable.Rows.Count > 0)
            {
                c = new Classroom();
                DataRow dataRow = dataTable.Rows[0];

                c.classroom= dataRow["classroom"].ToString();

            }

            return c;
        }
    }
}
