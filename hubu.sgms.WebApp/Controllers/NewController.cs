using hubu.sgms.BLL;
using hubu.sgms.DAL;
using NewWeb.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace hubu.sgms.WebApp.Controllers
{
    public class NewsController : Controller
    {
        //
       INewsServices NewInfoBll = new INewsServices();
       
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <returns></returns>
        public JsonResult ShowNewsList()
        {
            //要求返回的数据json对象  {total:200,rows:[{},{}]}
            int pageSize = int.Parse(Request["rows"]??"10");
            int pageIndex = int.Parse(Request["page"]??"1");
            List<News> newInfoList= NewInfoBll.GetPageEntityList(pageIndex, pageSize);
            //查询所有数据
            var allNews = NewInfoBll.GetRecordCount();
            //把totle和rows:[{},{}]一起返回
            //先建立一个匿名类
            var dataJson = new { total = allNews, rows = newInfoList };
            var json = Json(dataJson, JsonRequestBehavior.AllowGet);
            return json;
        }


        /// <summary>
        /// 根据id查询记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowModelById()
        {
            int id = int.Parse(Request["id"]);
            News model = NewInfoBll.GetEntityModel(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult test()
        {
            return View();
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            var r = NewInfoBll.DeleteNewInfo(id);
            if (r)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }


        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        /// 不允许验证
        [ValidateInput(false)]
        public ActionResult UpdateNewInfo()
        {
            News newInfo = null;
            newInfo = new News();
            newInfo.Id = Convert.ToInt32(Request["Id"]);
            newInfo.Title = Request["Title"];
            newInfo.Author = Request["Author"];
            newInfo.Msg = Request["UpdateMsg"];
            newInfo.ImagePath = Request["UpdateImagePath"];
            newInfo.SubDateTime = DateTime.Now;
            if (NewInfoBll.UpdateNewInfo(newInfo))
            {
                return View();
            }
            else
            {
                return Content("no");
            }
        }


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        public ActionResult FileUpload()
        {
            //接收文件
            HttpPostedFileBase file = Request.Files["MenuIcon"];
            //进行判断
            if (file == null)
            {
                return Content("no:上传文件不能为空!");
            }
            else 
            { 
                //获取文件名
                string fileName = Path.GetFileName(file.FileName);
                //获取文件扩展名(全部转换为大写)
                string fileExt = Path.GetExtension(fileName).ToUpper();
                //判断扩展名
                if (fileExt == ".JPG" || fileExt == ".PNG")
                {
                    //创建文件夹
                    string dir = "/FileUploadImage/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));
                    //更新文件名称
                    string newFileName = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second);
                    //全路径
                    string fullDir = dir + newFileName + fileExt;
                    //保存图片
                    file.SaveAs(Request.MapPath(fullDir));
                    //返回标识符和全路径
                    return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:上传文件格式错误");
                }
            }
        }
       
        
        
        
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <returns></returns>   
        [ValidateInput(false)]
        public ActionResult AddNewInfo()
        {
            News newInfo = null;
            newInfo = new News();
            newInfo.Title = Request["Title"];
            newInfo.Author = Request["Author"];
            newInfo.Msg= Request["Msg"]; 
            newInfo.ImagePath = Request["ImagePath"];
            newInfo.SubDateTime = DateTime.Now;
            if (NewInfoBll.AddNewInfo(newInfo))
            {
                // return Content("ok");
                return View();
            }
            else
            {
                return Content("no");
            }
        }

    }
}
