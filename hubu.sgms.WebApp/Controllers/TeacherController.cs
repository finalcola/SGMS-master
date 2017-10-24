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

        public ActionResult SelectCourse()
        {
            //身份判断
            Login login = (Login)Session["loginInfo"];

            if(login == null)
            {
                return Content("请先登录");
            }
            else
            {
                if(login.role != "1")
                {
                    return Content("不具有此权限");          
                }
                else
                {
                    //获取数据
                    return View();
                }
            }

        }
    }
}