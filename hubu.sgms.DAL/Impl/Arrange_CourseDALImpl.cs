using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL.Impl
{
    public class Arrange_CourseDALImpl : IArrange_CourseDAL
    {
       public int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id)
        {
            /*           //多级连接查询填写teacher_course表
                      string sql1 = "insert into teacher_course ( teacher_course_id,course_id,course_name , teacher_id, teacher_name,class_id,major,major_id ,department,college_id,course_credit)values(@teacher_course_id, @course_id, (select course_name from course where course_id = @course_id), @teacher_id,(select teacher_name from teacher where teacher_id = @teacher_id),@class_id,(select major_name from major where major_id in (select major_id from class where class_id = @class_id)),(select major_id from class where class_id = @class_id),(select name from college where college_id in (select college_id from major where major_id in(select major_id from class where class_id = @class_id))),(select college_id from major where major_id in(select major_id from class where class_id = @class_id)),(select course_credit from course where course_id = @course_id))";



                      SqlParameter[] pars1 = {
                          new SqlParameter("@teacher_course_id",course_id+teacher_id+class_id),
                          new SqlParameter("@classroom_id",classroom_id),
                          new SqlParameter("@teacher_id",teacher_id),
                          new SqlParameter("@class_id",class_id)
                      };*/

            string sql2 = "insert into Arrange_course values(@arrange_id,@teacher_course_id,@classroom_id,@time_id,'1')";

            SqlParameter[] pars2 = {
                new SqlParameter("@arrange_id",course_id+teacher_id+class_id+classroom_id+time_id),
                new SqlParameter("@teacher_course_id",course_id+teacher_id+class_id),
                new SqlParameter("@classroom_id",classroom_id),
                new SqlParameter("@time_id",time_id)
              
            };
            //插入
         //   int i = DBUtils.getDBUtils().cud(sql1, pars1);

            int j= DBUtils.getDBUtils().cud(sql2, pars2);

            return j;
        }
    }
}
