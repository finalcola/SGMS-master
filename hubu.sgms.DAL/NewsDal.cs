using NewWeb.Model;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hubu.sgms.DAL
{
    public  class NewsDal
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="start">分页开始条数</param>
        /// <param name="end">分页结束条数</param>
        /// <returns>返回查询到的list集合</returns>
        public List<News> GetPageEntityList(int start,int end)
        {
            string sql = "select * from(select row_number()over(order by id)as num,*from News)as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pms = { 
                                     new SqlParameter("@start",SqlDbType.Int),
                                     new SqlParameter("@end",SqlDbType.Int),
                                 };
            pms[0].Value = start;
            pms[1].Value = end;
            DataTable dt = SqlHelper.GetTable(sql,CommandType.Text,pms);
            List<News> newList = null;
            if (dt.Rows.Count>0)
            {
                newList = new List<News>();
                News newinfo = null;
                foreach (DataRow item in dt.Rows)
                {
                    newinfo = new News();
                    LoadEntity(item,newinfo);
                    newList.Add(newinfo);
                }
            }
            return newList;
        }

       
        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        public List<News> GetEntityList()
        {
            string sql = "select * from  News";
            DataTable dt = SqlHelper.GetTable(sql, CommandType.Text);
            List<News> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<News>();
                News newInfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    newInfo = new News();
                    LoadEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }


        /// <summary>
        /// 查询出页面条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from News";
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sql,CommandType.Text));
            return count;
        }



        /// <summary>
        /// 根据id查询出记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetEntityModel(int id)
        {
            string sql = "select * from News  where Id=@Id";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Id", id));
            News newInfo = null;
            if (da.Rows.Count > 0)
            {
                newInfo = new News();
                LoadEntity(da.Rows[0], newInfo);
            }
            return newInfo;

        }



        /// <summary>
        /// 根据id删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteNewInfo(int id)
        {
            string sql = "delete from News  where Id=@Id";
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }


        public int UpdateNewInfo(News newInfo)
        {
            string sql = "update News set Title=@Title,Msg=@Msg,Author=@Author,SubDateTime=@SubDateTime,ImagePath=@ImagePath where Id=@Id";
            SqlParameter[] pars = {
                                 new SqlParameter("@Id",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                 new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                 new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                 new SqlParameter("@ImagePath",SqlDbType.NVarChar,100)
                               };
            pars[0].Value = newInfo.Id;
            pars[1].Value = newInfo.Title;
            pars[2].Value = newInfo.Msg;
            pars[3].Value = newInfo.Author;
            pars[4].Value = newInfo.SubDateTime;
            pars[5].Value = newInfo.ImagePath;
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }


        public void LoadEntity(DataRow item, News newinfo)
        {
            newinfo.Id = Convert.ToInt32(item["Id"]);
            newinfo.Title = item["Title"] != DBNull.Value ? item["Title"].ToString() : string.Empty;
            newinfo.Msg = item["Msg"] != DBNull.Value ? item["Msg"].ToString() : string.Empty;
            newinfo.ImagePath = item["ImagePath"] != DBNull.Value ? item["ImagePath"].ToString() : string.Empty;
            newinfo.SubDateTime = Convert.ToDateTime(item["SubDateTime"]);
            newinfo.Author = item["Author"] != DBNull.Value ? item["Author"].ToString() : string.Empty;
        }



        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public int AddNewInfo(News newInfo)
        {
       /*     DateTime dt_new = DateTime.Now;
            DateTime dt_old = new DateTime(2010, 1, 1, 0, 0, 0);
            TimeSpan ts = dt_new.Subtract(dt_old).Duration();
            string dateDiff = ts.Days.ToString() + ts.Hours.ToString() + ts.Minutes.ToString() + ts.Seconds.ToString();
            newInfo.Id = Convert.ToInt32(dateDiff.ToString());
        */
            string sql = "insert into News(Title,Msg,Author,SubDateTime,ImagePath) values(@Title,@Msg,@Author,@SubDateTime,@ImagePath)";
            SqlParameter[] pars = { 
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                   new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                   new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                   new SqlParameter("@ImagePath",SqlDbType.NVarChar,100)
                                 };
            pars[0].Value = newInfo.Title;
            pars[1].Value = newInfo.Msg;
            pars[2].Value = newInfo.Author;
            pars[3].Value = newInfo.SubDateTime;
            pars[4].Value = newInfo.ImagePath;
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
    }
}
