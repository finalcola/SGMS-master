using hubu.sgms.Model;
using hubu.sgms.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL.Impl
{
    public class CollegeDALImpl : ICollegeDAL
    {
        private static ICollegeDAL collegeDAL = new CollegeDALImpl();

        public static ICollegeDAL Instance()
        {
            return collegeDAL;
        }

        public string SelectId(string collegeName)
        {
            //数据库中的college_namew应从text改为varchar
            string sql = "select college_id from college where name = @college_name ";

            SqlParameter[] parameters = {
                new SqlParameter("@college_name",collegeName)
            };

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            DataRow row = dataTable.Rows[0];
            string collegeId = row["college_id"].ToString();

            return collegeId;
        }


        public IList<College> SelectColleges()
        {
            string sql = "select college_id,name,sort,student_number,teacher_number,class_number from College order by sort asc";

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql);

            //存放结果的list
            IList<College> collegeList = new List<College>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //college_id,name,sort,student_number,teacher_number,class_number 
                College college = new College();
                college.college_id = dataRow["college_id"].ToString();
                college.name = dataRow["name"].ToString();
                college.sort = Convert.ToInt32(dataRow["sort"]);
                college.student_number = Convert.ToInt32(dataRow["student_number"]);
                college.teacher_number = Convert.ToInt32(dataRow["teacher_number"]);
                college.class_number = Convert.ToInt32(dataRow["class_number"]);
                collegeList.Add(college);
            }

            return collegeList;
        }

        public College SelectById(string id)
        {
            string sql = "select * from College where college_id=@id";
            SqlParameter[] parameters = {
                new SqlParameter("@id",id)
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql,parameters);
            College college = new College();
            college.college_id = id;
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                BeanUils.SetStringValues(college, row);
                college.sort = Convert.ToInt32(row["sort"]);
                college.student_number = Convert.ToInt32(row["student_number"]);
                college.class_number = Convert.ToInt32(row["class_number"]);
                college.teacher_number = Convert.ToInt32(row["teacher_number"]);

            }

            return college;
            
        }

        public IList<College> SelCollegeforArrangeCourse()
        {
            string sql = "select distinct college.college_id ,college.name from college,course where course.college_id=college.college_id and course.college_id in (select  college_id from Course )";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql);

            IList<College> collegeList = new List<College>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                College c = new College();
                c.college_id = dataTable.Rows[i]["college_id"].ToString();
                c.name = dataTable.Rows[i]["name"].ToString();
                collegeList.Add(c);
            }
            // foreach (DataRow dataRow in dataTable["name"].Rows)
            //  {
            //  c.college_id = dataRow["college_id"].ToString();
            //       c.name = dataRow["name"].ToString();
            //       collegeList.Add(c);
            //   }
            return collegeList;
        }


        public College SelCollegeById(string id)
        {
            string sql = "select name from college where college_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",id),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            College c = null;


            if (dataTable.Rows.Count > 0)
            {
                c = new College();
                DataRow dataRow = dataTable.Rows[0];

                c.name = dataRow["name"].ToString();

            }

            return c;
        }

    }
}
