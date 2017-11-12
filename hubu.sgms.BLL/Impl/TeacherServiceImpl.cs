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
    public class TeacherServiceImpl : ITeacherService
    {
        ITeacherDAL teacherDAL = new TeacherDALImpl();

        public IList<Teacher_course> SelectAllCourse(string teacher_id)
        {
            return teacherDAL.SelectAllCourse(teacher_id);
        }

        public IList<Course_choosing> SelectAllStudentCourse(string courseId)
        {
            return teacherDAL.SelectAllStudentCourse(courseId);
        }

        public int InsertStudentGrade(string usual_grade, string test_grade, string total_grade,string student_id)
        {
            return teacherDAL.InsertStudentGrade(usual_grade, test_grade, total_grade, student_id);
        }

        public Status GetAllStatus()
        {
            return teacherDAL.GetAllStatus();
        }

        public void SetAllStatus(string mystatus)
        {
            teacherDAL.SetAllStatus(mystatus);
        }

        public Status GetStatus(string courseid)
        {
            return teacherDAL.GetStatus(courseid);
        }

        public void SetStatus(string mystatus, string courseid)
        {
            teacherDAL.SetStatus(mystatus, courseid);
        }

        public IList<Teacher> SelTeacherByCollegeId(string CollegeId)
        {
            return teacherDAL.SelTeacherByCollegeId(CollegeId);
        }

        public Teacher SelTeacherByTeacherId(string TeacherId)
        {
            return teacherDAL.SelTeacherByTeacherId(TeacherId);
        }
    }
}
