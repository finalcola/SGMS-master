using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherService teacherService = new TeacherServiceImpl();

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回所有课程信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCourse()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string teacher_id = Session["teacher_id"].ToString();
            IList<Teacher_course> courseList = teacherService.SelectAllCourse(teacher_id);
            return Json(new { courseList = courseList });
        }


        /// <summary>
        /// 学生打分信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStudentInfo()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string courseId;
            if (Session["course_id"] == null)
            {
                courseId = Request["courseid"];
            }
            else
            {
                courseId = Session["course_id"].ToString();
            }
        
            Status status = teacherService.GetStatus(courseId);

            IList<Course_choosing> studentList = teacherService.SelectAllStudentCourse(courseId);          
            return Json(new { studentList = studentList , status = status }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看当前情况
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStudentInfo2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string courseId;
            if (Session["course_id"] == null)
            {
                courseId = Request["courseid"];
            }
            else
            {
                courseId = Session["course_id"].ToString();
            }     

            IList<Course_choosing> studentList = teacherService.SelectAllStudentCourse(courseId);
            return Json(new { studentList = studentList, status = "0" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 教师主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherManager()
        {
            //教师登录后在session中写入教师id
            //获取教师登录的id
            Login info = (Login)Session["loginInfo"];
            if(info == null)
            {
                return RedirectToAction("Index","Login");
            }

            Session.Add("teacher_id", info.username);
            return View();
        }

        /// <summary>
        /// 教师打分
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherCheckScore()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //此处需要在session中设置课程号
            string course_id = Request["courseid"];
            Session.Add("course_id", course_id);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherCheckScore2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //此处需要在session中设置课程号
            string course_id = Request["courseid"];
            Session.Add("course_id", course_id);
            return View();
        }

        /// <summary>
        /// 老师查看课程
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherSelectCourse()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        /// <summary>
        /// 老师查看课程和成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherSelectCourse2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult SetScore()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //设置session
            string courseid = Session["course_id"].ToString();
            //保存成绩
            if(Request["myflag"] == "" || Request["myflag"] == null)
            {
                Response.Write("<script>alert('无效')</script>");
                return null;
            }

            int count = Convert.ToInt32(Request["myflag"]);
            
            for(int i=1; i<=count; i++)
            {
                string mystudent = "student_id" + i;
                string myusual = "usual_grade" + i;
                string mytest = "test_grade" + i;
                string mytotal = "total_grade" + i;

                string student_id = Request[mystudent];               
                string usual_grade = Request[myusual];
                string test_grade = Request[mytest];               
                string total_grade = Request[mytotal];

                teacherService.InsertStudentGrade(usual_grade, test_grade, total_grade, student_id);

            }

            //设置状态
            string mystatus = Request["mystatus"];
          
            string mycourseid = Request["mycourse"];
            if(mystatus == "0")
            {
                //保存状态，页面上不能修改成绩
                teacherService.SetStatus(mystatus, mycourseid);
            }

            return RedirectToAction("TeacherCheckScore",new { courseid = courseid });
        }
    }
}