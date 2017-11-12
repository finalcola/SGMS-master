using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ITeacherDAL
    {
        /// <summary>
        /// 查询所有的课程信息
        /// </summary>
        /// <param name="teacher_id"></param>
        /// <returns></returns>
        IList<Teacher_course> SelectAllCourse(string teacher_id);

        Teacher SelTeacherByTeacherId(string TeacherId);

        /// <summary>
        /// 查询所有选课信息
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="_class"></param>
        /// <param name="courseid"></param>
        /// <returns></returns>
        IList<Course_choosing> SelectAllStudentCourse(string courseid);

        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <param name="usual_grade"></param>
        /// <param name="test_grade"></param>
        /// <param name="student_id"></param>
        /// <param name="proportion"></param>
        /// <returns></returns>
        int InsertStudentGrade(string usual_grade, string test_grade, string total_grade, string student_id);

        /// <summary>
        /// 获取全局系统状态
        /// </summary>
        /// <returns></returns>
        Status GetAllStatus();

        /// <summary>
        /// 设置系统全局状态
        /// </summary>
        /// <param name="mystatus"></param>
        void SetAllStatus(string mystatus);

        /// <summary>
        /// 获取某一课程的打分状态
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        Status GetStatus(string courseid);

        /// <summary>
        /// 设置某一课程的打分状态
        /// </summary>
        /// <param name="mystatus"></param>
        /// <param name="courseid"></param>
        void SetStatus(string mystatus, string courseid);

        IList<Teacher> SelTeacherByCollegeId(string CollegeId);

    }
}
