using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL.Impl
{
    public class Teacher_CourseServiceImpl:ITeacher_CourseService
    {
        ITeacher_CourseDAL Teacher_CourseDAL = new Teacher_CourseDALImpl();

        public int AddTeacher_Course(string course_id, string teacher_id, string class_id,string classroom_id,string time_id)
        {
            return Teacher_CourseDAL.AddTeacher_Course(course_id, teacher_id, class_id);

        }

        int ITeacher_CourseService.AddTeacher_Course(string course_id, string teacher_id, string class_id)
        {
            return Teacher_CourseDAL.AddTeacher_Course(course_id, teacher_id, class_id);
        }

       public  IList<Teacher_course> SelTeacher_CourseByDetail(string course_id, string teacher_id, string class_id)
        {
            return Teacher_CourseDAL.SelTeacher_CourseByDetail(course_id, teacher_id, class_id);
        }
    }

    
}
