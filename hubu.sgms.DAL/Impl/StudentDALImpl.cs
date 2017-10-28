using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using System.Data.SqlClient;
using System.Data;
using hubu.sgms.Utils;

namespace hubu.sgms.DAL.Impl
{
    public class StudentDALImpl : IStudengDAL
    {

        private StudentDALImpl()
        {

        }

        private static StudentDALImpl studentDAL = new StudentDALImpl();

        public static IStudengDAL Instance()
        {
            return studentDAL;
        }

        public Student SelectStudentById(string stuId)
        {
            string sql = "select * from Student where student_id=@student_id ";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@student_id",stuId)
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, sqlParameter);
            Student student = new Student();
            if (dataTable.Rows.Count > 0)
            {
                BeanUils.SetStringValues(student, dataTable.Rows[0]);
                DataRow row = dataTable.Rows[0];
                if (row["student_age"] != null)
                {
                    student.student_age = Int32.Parse(row["student_age"].ToString());
                }
                if (row["status"] != null)
                {
                    student.status = Int32.Parse(row["status"].ToString());
                }
                return student;
            }
            return null;
        }
    }
}
