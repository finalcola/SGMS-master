using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private ICourseService courseService = new CourseServiceImpl();
        private IRoleInfoService roleInfoService = new RoleInfoServiceImpl();

         // 生成ID方法
        public string CreateID()
        {
            DateTime dt_new = DateTime.Now;
            DateTime dt_old = new DateTime(2010, 1, 1, 0, 0, 0);
            TimeSpan ts = dt_new.Subtract(dt_old).Duration();
            string dateDiff = ts.Days.ToString() + ts.Hours.ToString() + ts.Minutes.ToString() + ts.Seconds.ToString();
            string ID = dateDiff.ToString();
            return ID;
        }
        // Admin后台中心主界面
        public ActionResult Index()
        {
            return View();
        }

        //管理员操纵学生信息界面
        public ActionResult AdminOperateStudent()
        {
            return View();
        }

        //学生改密码
        public ActionResult StudentChangePassword()
        {
            return View();
        }

        //添加学生信息
        public ActionResult AddCourseInfo()
        {
            return View();
        }

        //提交添加课程的信息
        public ActionResult SubmitAddCourseInfo()
        {
            // 获取用户提交的表单内容
            //Request courseRequest = new Request();
            string CourseID="20171010";
            string CourseName = Request["course_name"];
            string courseCredit = Request["course_credit"];  //数字+汉字
            string CourseHour = Request["course_hour"];
            string CourseType = Request["course_type"];     //null
            string CourseDepartement = Request["course_department"];     //null
            string CourseClass = Request["course_class"];     //null
            string CourseTheory = Request["course_theory"];
            string CourseExperiment = Request["course_experiment"];
            string CourseOpentime = Request["course_opentime"];
            string CoursePrior = Request["course_prior"];
            string courseStatus = Request["course_status"];     //null

            //部分转换数据类型
            decimal CourseCredit = 0;
            int CourseStatus = 3;
            if (courseCredit != null)
            {
                CourseCredit = Convert.ToDecimal(courseCredit);
            }
            if (courseStatus != null)
            {
                if (courseStatus == "待开课")
                {
                    courseStatus = "1";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
                else if (courseStatus == "已开课")
                {
                    courseStatus = "2";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
                else
                {
                    courseStatus = "3";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
            }
            string result = courseService.AddCourseBaseInfo(CourseID,CourseName, CourseCredit, CourseHour, CourseType, CourseDepartement, CourseClass, CourseTheory, CourseExperiment, CourseOpentime, CoursePrior, CourseStatus);

            ViewData["courseType"] = CourseType;
            return View();
        }


        //更新课程信息
        public ActionResult UpdateCourseInfo(int courseId)
        { 
            Course course = courseService.SelectCourseById(courseId);
            ViewData["courseID"] = course.course_id;
            ViewData["courseName"] = course.course_name;
            ViewData["courseCredit"] = course.course_credit;
            ViewData["courseHour"] = course.course_hour;
            ViewData["courseType"] = course.course_type;
            ViewData["courseTheory"] = course.course_theory;
            ViewData["collegeID"] = course.college_id;
            ViewData["classID"] = course.class_id;
            ViewData["courseExperiment"] = course.course_experiment;
            ViewData["courseOpentime"] = course.course_opentime;
            ViewData["coursePrior"] = course.course_prior;
            ViewData["status"] = course.status;
            return View();
        }


        //提交更新的课程信息
        public ActionResult SubmitUpdateCourseInfo()
        {
            // 获取用户提交的表单内容
            string CourseID = Request["course_id"];
            string CourseName = Request["course_name"];
            string courseCredit = Request["course_credit"];
            string CourseHour = Request["course_hour"];
            string CourseType = Request["course_type"];
            string CourseDepartement = Request["course_departement"]; 
            string CourseClass = Request["course_class"];
            string CourseTheory = Request["course_theory"];
            Console.Write(CourseTheory);
            string CourseExperiment = Request["course_experiment"];
            string CourseOpentime = Request["course_opentime"];
            string CoursePrior = Request["course_prior"];
            string courseStatus = Request["course_status"];

            decimal CourseCredit = 0;
            int CourseStatus = 3;
            if (courseCredit != null)
            {
                CourseCredit = Convert.ToDecimal(courseCredit);
            }
            if (courseStatus != null)
            {
                if (courseStatus == "待开课")
                {
                    courseStatus = "1";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
                else if (courseStatus == "已开课")
                {
                    courseStatus = "2";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
                else
                {
                    courseStatus = "3";
                    CourseStatus = Convert.ToInt32(courseStatus);
                }
            }

            string result = courseService.UpdateCourseBaseInfo(CourseID,CourseName, CourseCredit, CourseHour, CourseType, CourseDepartement, CourseClass, CourseTheory, CourseExperiment, CourseOpentime, CoursePrior, CourseStatus);
            Response.Write("修改成功");
            return View();
        }


        //查看课程页面
        public ActionResult ViewCourseInfo(int courseId)
             //public ActionResult ViewCourseInfo()
        {
            Course course = courseService.SelectCourseById(courseId);
            ViewData["courseName"] = course.course_name;
            ViewData["courseCredit"] = course.course_credit;
            ViewData["courseHour"] = course.course_hour;
            ViewData["courseType"] = course.course_type;
            ViewData["courseTheory"] = course.course_theory;
            ViewData["collegeID"] = course.college_id;
            ViewData["classID"] = course.class_id;
            ViewData["courseExperiment"] = course.course_experiment;
            ViewData["courseOpentime"] = course.course_opentime;
            ViewData["coursePrior"] = course.course_prior;
            ViewData["status"] = course.status;
         
            //ViewData["coursePhoto"] = course.yuliu1;
            return View();
        }

        //查询课程页面
        public ActionResult AlterCourseInfo()
        {
            return View();
        }

        // 删除课程
        public ActionResult DeleteCourseInfo(int courseId)
        {
            string result = courseService.DeleteCourseBaseInfo(courseId.ToString());
            return View("AlterCourseInfo");
        }



        #region 增删查改-管理员
        // 管理员添加个人信息
        public ActionResult AddAdminInfo()
        {
            return View();
        }
        public ActionResult SubmitAddAdminInfo()
        {
            string adminID = CreateID();
            string adminName = Request["adminName"];
            string adminSex = Request["adminSex"];
            string adminIDCard = Request["adminIDCard"];
            string adminDepartment = Request["adminDepartment"];
            string adminContact = Request["adminContact"];
            string adminOther = Request["adminOther"];
            string AdminStatus = Request["adminStatus"];
            // 转换数据类型
            int adminStatus = Convert.ToInt32(AdminStatus);

            string result = roleInfoService.AddAdminInfo(adminID, adminName, adminSex, adminIDCard, adminDepartment, adminContact, adminOther, adminStatus);

            return View();
        }

        // 管理员修改个人信息界面
        public ActionResult AlterAdminInfo()
        {
            string sqlNull = "2b婿s1jHh子1hl91";  // 赋值，防止sql报错
            string adminDepartment = Request["adminDepartment"];
            string adminName = Request["adminName"];
            
            if (adminName == null && adminDepartment == null)   //一开始加载不显示
            {
                return View();
            }
            if(adminName == "" && adminDepartment == null)  //都没有输入
            {
                adminDepartment = adminName = sqlNull;
            }
            if (adminName == "" && adminDepartment != null)     //只输入院系
            {
                adminName = sqlNull;
            }
            if(adminName != "" && adminDepartment == null) //只输入姓名
            {
                adminDepartment = sqlNull;
            }
            List<Administrator> administratorList = roleInfoService.SelectAllAdminInfo(adminName, adminDepartment);
            ViewData["adminList"] = administratorList;
            return View();
        }
        public ActionResult UpdateAdminInfo(string administratorId)
        {
            Administrator admiadministrator = roleInfoService.SelectAdministratorByID(administratorId);

            ViewData["administrator_id"] = admiadministrator.administrator_id;
            ViewData["administrator_name"] = admiadministrator.administrator_name;
            ViewData["administratort_sex"] = admiadministrator.administratort_sex;
            ViewData["administrator_contact"] = admiadministrator.administrator_contact;
            ViewData["administrator_department"] = admiadministrator.administrator_department;
            ViewData["administrator_id_card"] = admiadministrator.administrator_id_card;
            ViewData["administrator_other"] = admiadministrator.administrator_other;
            ViewData["administrator_photo"] = admiadministrator.administrator_photo;
            ViewData["status"] = admiadministrator.status;

            return View();
        }
        public ActionResult SubmitUpdateAdminInfo()
        {
            string adminID = Request["administrator_id"];
            string adminName = Request["administrator_name"];
            string adminSex = Request["administrator_sex"];
            string adminIDCard = Request["administrator_id_card"];
            string adminContact = Request["administrator_contact"];
            string adminDepartment = Request["administrator_department"];
            string adminOther = Request["administrator_other"];
            string status = Request["status"];
            //数据类型转换
            int adminStatus = Convert.ToInt32(status);

            string result = roleInfoService.UpdateAdminInfo(adminID, adminName, adminSex, adminIDCard, adminDepartment, adminContact, adminOther, adminStatus);
            return View();
        }

        // 查看管理员详细信息
        public ActionResult ViewAdminInfo(string administratorId)
        {
            Administrator admiadministrator = roleInfoService.SelectAdministratorByID(administratorId);

            ViewData["administrator_id"] = admiadministrator.administrator_id;
            ViewData["administrator_name"] = admiadministrator.administrator_name;
            ViewData["administratort_sex"] = admiadministrator.administratort_sex;
            ViewData["administrator_contact"] = admiadministrator.administrator_contact;
            ViewData["administrator_department"] = admiadministrator.administrator_department;
            ViewData["administrator_id_card"] = admiadministrator.administrator_id_card;
            ViewData["administrator_other"] = admiadministrator.administrator_other;
            ViewData["administrator_photo"] = admiadministrator.administrator_photo;
            ViewData["status"] = admiadministrator.status;

            return View();
        }

        // 删除管理员
        public ActionResult DeleteAdmin(string administratorId)
        {
            string result = roleInfoService.DeleteAdmin(administratorId);
            return View("AlterAdminInfo");
        }
        #endregion

        #region 增删查改-教师
        // 添加教师信息
        public ActionResult AddTeacherInfo()
        {
            return View();
        }
        public ActionResult SubmitAddTeacherInfo()
        {
            string teacherID = CreateID();
            string teacherName = Request["teacherName"];
            string teacherSex = Request["teacherSex"];
            string teacherIDCard = Request["teacherIDCard"];
            string TeacherAge = Request["teacherAge"];
            string teacherDepartment = Request["teacherDepartment"];
            string teacherTitle = Request["teacherTitle"];
            string teacherNative = Request["teacherNative"];
            string teacherBirthplace = Request["teacherBirthplace"];
            string teacherPoliticsstatus = Request["teacherPoliticsstatus"];
            string teacherTeachingtime = Request["teacherTeachingtime"];
            string teacherContact = Request["teacherContact"];
            string teacherOther = Request["teacherOther"];
            string TeacherStatus = Request["teacherStatus"];

            // 转换数据类型
            int teacherAge = Convert.ToInt32(TeacherAge);
            int teacherStatus = Convert.ToInt32(TeacherStatus);

            string result = roleInfoService.AddTeacherInfo(teacherID, teacherName, teacherSex, teacherIDCard, teacherAge, teacherDepartment, teacherTitle, teacherNative, teacherBirthplace, teacherPoliticsstatus, teacherTeachingtime, teacherContact, teacherOther, teacherStatus);

            return View();
        }

        // 管理员修改教师信息
        public ActionResult AdminAlterTeacherInfo()
        {
            string teacherName = Request["teacherName"];
            string teacherDepartment = Request["teacherDepartment"];
            if (teacherName == null && teacherDepartment == null)   //刚加载页面时不显示信息
            {
                return View();
            }
            if (teacherName == "" && teacherDepartment != null)  //查询某学院教师
            {
                teacherName = "2b婿s1jHh子1hl91";         //赋值，防止sql报错
            }
            if (teacherName != null && teacherName != "" && teacherDepartment == null)  //查询姓名教师
            {
                teacherDepartment = "2b婿s1jHh子1hl91";         //赋值，防止sql报错
            }
            if (teacherName == "" && teacherDepartment == null)    //即在页面没输入姓名和学院时，点击查询时查询所有信息
            {
                teacherDepartment = "2b婿s1jHh子1hl91";   //赋值，防止sql报错
                teacherName = "2b婿s1jHh子1hl91";         //赋值，防止sql报错
            }
            List<Teacher> teacherList = roleInfoService.SelectAllTeacherInfo(teacherName, teacherDepartment);
            ViewData["teacherList"] = teacherList;
            return View();
        }
        public ActionResult AdminUpdateTeacherInfo(string teacherID)
        {
            Teacher teacher = roleInfoService.SelectTeacherByID(teacherID);

            ViewData["teacher_id"] = teacher.teacher_id;
            ViewData["teacher_name"] = teacher.teacher_name;
            ViewData["teachert_sex"] = teacher.teachert_sex;
            ViewData["teacher_id_card"] = teacher.teacher_id_card;
            ViewData["teachert_age"] = teacher.teachert_age;
            ViewData["teacher_department"] = teacher.teacher_department;
            ViewData["teacher_title"] = teacher.teacher_title;
            ViewData["teacher_native"] = teacher.teacher_native;
            ViewData["teacher_birthplace"] = teacher.teacher_birthplace;
            ViewData["teacher_photo"] = teacher.teacher_photo;
            ViewData["teacher_politicsstatus"] = teacher.teacher_politicsstatus;
            ViewData["teacher_teachingtime"] = teacher.teacher_teachingtime;
            ViewData["teacher_contact"] = teacher.teacher_contact;
            ViewData["teacher_other"] = teacher.teacher_other;
            ViewData["status"] = teacher.status;

            return View();
        }
        public ActionResult SubmitAdminUpdateTeacherInfo()
        {
            string teacherID = Request["teacherID"];
            string teacherName = Request["teacherName"];
            string teacherSex = Request["teacherSex"];
            string teacherIDCard = Request["teacherIDCard"];
            string TeacherAge = Request["teacherAge"];
            string teacherDepartment = Request["teacherDepartment"];
            string teacherTitle = Request["teacherTitle"];
            string teacherNative = Request["teacherNative"];
            string teacherBirthplace = Request["teacherBirthplace"];
            string teacherPoliticsstatus = Request["teacherPoliticsstatus"];
            string teacherTeachingtime = Request["teacherTeachingtime"];
            string teacherContact = Request["teacherContact"];
            string teacherOther = Request["teacherOther"];
            string TeacherStatus = Request["teacherStatus"];

            // 转换数据类型
            int teacherAge = Convert.ToInt32(TeacherAge);
            int teacherStatus = Convert.ToInt32(TeacherStatus);

            string result = roleInfoService.UpdateTeacherInfo(teacherID, teacherName, teacherSex, teacherIDCard, teacherAge, teacherDepartment, teacherTitle, teacherNative, teacherBirthplace, teacherPoliticsstatus, teacherTeachingtime, teacherContact, teacherOther, teacherStatus);

            return View();
        }

        // 查看教师详细信息
        public ActionResult ViewTeacherInfo(string teacherID)
        {
            Teacher teacher = roleInfoService.SelectTeacherByID(teacherID);

            ViewData["teacher_id"] = teacher.teacher_id;
            ViewData["teacher_name"] = teacher.teacher_name;
            ViewData["teachert_sex"] = teacher.teachert_sex;
            ViewData["teacher_id_card"] = teacher.teacher_id_card;
            ViewData["teachert_age"] = teacher.teachert_age;
            ViewData["teacher_department"] = teacher.teacher_department;
            ViewData["teacher_title"] = teacher.teacher_title;
            ViewData["teacher_native"] = teacher.teacher_native;
            ViewData["teacher_birthplace"] = teacher.teacher_birthplace;
            ViewData["teacher_photo"] = teacher.teacher_photo;
            ViewData["teacher_politicsstatus"] = teacher.teacher_politicsstatus;
            ViewData["teacher_teachingtime"] = teacher.teacher_teachingtime;
            ViewData["teacher_contact"] = teacher.teacher_contact;
            ViewData["teacher_other"] = teacher.teacher_other;
            ViewData["status"] = teacher.status;

            return View();
        }

        // 管理员删除教师
        public ActionResult AdminDeleteTeacher(string teacherID)
        {
            string result = roleInfoService.AdminDeleteTeacher(teacherID);
            return View("AdminAlterTeacherInfo");
        }
        #endregion


        #region 增删查改-学生
        // 添加学生信息
        public ActionResult AddStudentInfo()
        {
            return View();
        }
        public ActionResult SubmitAddStudentInfo()
        {
            string studentID = CreateID();
            string studentName = Request["studentName"];
            string studentSex = Request["studentSex"];
            string studentIDCard = Request["studentIDCard"];
            string StudentAge = Request["studentAge"];
            string studentDepartment = Request["studentDepartment"];
            string studentMajor = Request["studentMajor"];
            string studentGrade = Request["studentGrade"];
            string studentType = Request["studentType"];
            string studentAddress = Request["studentAddress"];
            string studentNative = Request["studentNative"];
            string studentBirthplace = Request["studentBirthplace"];
            string studentPoliticsstatus = Request["studentPoliticsstatus"];
            string studentContact = Request["studentContact"];
            string studentFamily = Request["studentFamily"];
            string studentAward = Request["studentAward"];
            string studentOther = Request["studentOther"];
            string StudentStatus = Request["studentStatus"];

            string studentClass = Request["classlist"];

            //数据类型转换
            int studentAge = Convert.ToInt32(StudentAge);
            int studentStatus = Convert.ToInt32(StudentStatus);

            string result = roleInfoService.AddStudentInfo(studentID, studentName, studentSex, studentIDCard, studentAge, studentDepartment, studentMajor, studentGrade, studentType, studentAddress, studentNative, studentBirthplace, studentPoliticsstatus, studentContact, studentFamily, studentAward, studentOther, studentStatus,studentClass);

            return View();
        }

        // 管理员修改学生信息
        public ActionResult AdminAlterStudentInfo()
        {
            string sqlNull = "2b婿s1jHh子1hl91";  //防止参数为空，使sql报错
            string studentName = Request["studentName"];
            string studentDepartment = Request["studentDepartment"];
            string studentMajor = Request["majorlist"];
            string studentClass = Request["classlist"];
            
            if(studentDepartment == null && studentName == null)    //刚加载页面时不显示信息
            {
                return View();
            }
            if (studentDepartment == null && studentName == "")   //没有输入信息
            {
                studentDepartment = studentName = studentMajor = studentClass = sqlNull;  //赋值,防止sql报错
            }
            if (studentDepartment != null && studentMajor =="" && studentName == "")   //只输入学院信息
            {
                studentName = studentMajor = studentClass = sqlNull;  //赋值,防止sql报错
            }
            if(studentMajor != "" && studentClass == "" && studentName == "")   //只输入学院，专业
            {
                studentName = studentClass = sqlNull;
            }
            if(studentClass != "" && studentName == "")   //只输入学院，专业，班级
            {
                studentName = sqlNull;
            }
            if (studentDepartment == null && studentName != "")   //只输入姓名
            {
                studentDepartment = studentMajor = studentClass = sqlNull;  //赋值,防止sql报错
            }
            if (studentDepartment != null && studentMajor == "" && studentName != "")   //只输入学院，姓名
            {
                studentMajor = studentClass = sqlNull;
            }
            if (studentMajor != null && studentClass == null && studentName != "")   //只输入学院，专业，姓名
            {
                studentClass = sqlNull;
            }

            
            List<Student> studentList = roleInfoService.SelectAllStudentInfo(studentName, studentDepartment, studentMajor, studentClass);
            ViewData["studentList"] = studentList;
            return View();
        }
        public ActionResult AdminUpdateStudentInfo(string studentID)
        {
            Student student = roleInfoService.SelectStudent(studentID);

            ViewData["student_id"] = student.student_id;
            ViewData["student_name"] = student.student_name;
            ViewData["student_sex"] = student.student_sex;
            ViewData["student_age"] = student.student_age;
            ViewData["student_id_card"] = student.student_id_card;
            ViewData["student_department"] = student.student_department;
            ViewData["student_major"] = student.student_major;
            ViewData["student_grade"] = student.student_grade;
            ViewData["student_type"] = student.student_type;
            ViewData["student_address"] = student.student_address;
            ViewData["student_native"] = student.student_native;
            ViewData["student_birthplace"] = student.student_birthplace;
            ViewData["student_politicsstatus"] = student.student_politicsstatus;
            ViewData["student_contact"] = student.student_contact;
            ViewData["student_family"] = student.student_family;
            ViewData["student_award"] = student.student_award;
            ViewData["student_other"] = student.student_other;
            ViewData["status"] = student.status;

            return View();
        }
        public ActionResult SubmitAdminUpdateStudentInfo()
        {
            string studentID = Request["studentID"];
            string studentName = Request["studentName"];
            string studentSex = Request["studentSex"];
            string studentIDCard = Request["studentIDCard"];
            string StudentAge = Request["studentAge"];
            string studentDepartment = Request["studentDepartment"];
            string studentMajor = Request["studentMajor"];
            string studentGrade = Request["studentGrade"];
            string studentType = Request["studentType"];
            string studentAddress = Request["studentAddress"];
            string studentNative = Request["studentNative"];
            string studentBirthplace = Request["studentBirthplace"];
            string studentPoliticsstatus = Request["studentPoliticsstatus"];
            string studentContact = Request["studentContact"];
            string studentFamily = Request["studentFamily"];
            string studentAward = Request["studentAward"];
            string studentOther = Request["studentOther"];
            string StudentStatus = Request["studentStatus"];

            //数据类型转换
            int studentAge = Convert.ToInt32(StudentAge);
            int studentStatus = Convert.ToInt32(StudentStatus);

            string result = roleInfoService.UpdateStudentInfo(studentID, studentName, studentSex, studentIDCard, studentAge, studentDepartment, studentMajor, studentGrade, studentType, studentAddress, studentNative, studentBirthplace, studentPoliticsstatus, studentContact, studentFamily, studentAward, studentOther, studentStatus);

            return View("AdminAlterStudentInfo");
        }

        // 查看学生详细信息
        public ActionResult ViewStudentInfo(string studentID)
        {
            Student student = roleInfoService.SelectStudent(studentID);

            ViewData["student_id"] = student.student_id;
            ViewData["student_name"] = student.student_name;
            ViewData["student_sex"] = student.student_sex;
            ViewData["student_age"] = student.student_age;
            ViewData["student_id_card"] = student.student_id_card;
            ViewData["student_department"] = student.student_department;
            ViewData["student_major"] = student.student_major;
            ViewData["student_grade"] = student.student_grade;
            ViewData["student_type"] = student.student_type;
            ViewData["student_address"] = student.student_address;
            ViewData["student_native"] = student.student_native;
            ViewData["student_birthplace"] = student.student_birthplace;
            ViewData["student_politicsstatus"] = student.student_politicsstatus;
            ViewData["student_contact"] = student.student_contact;
            ViewData["student_family"] = student.student_family;
            ViewData["student_award"] = student.student_award;
            ViewData["student_other"] = student.student_other;
            ViewData["status"] = student.status;

            return View();
        }

        // 管理员删除学生
        public ActionResult AdminDeleteStudent(string studentID)
        {
            string result = roleInfoService.AdminDeleteStudent(studentID);
            return View("AdminAlterStudentInfo");
        }
        #endregion

    }
}