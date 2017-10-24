using NewWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    
    public class INewsServices
    {
        DAL.NewsDal NewInfoDal = new DAL.NewsDal();

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageSize">一个多少条数据</param>
        /// <returns></returns>
        public List<News> GetPageEntityList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageSize * pageIndex;
            return NewInfoDal.GetPageEntityList(start,end);
        }



        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        public List<News> GetEntityList()
        {
            return NewInfoDal.GetEntityList();
        }


        /// <summary>
        /// 查询出页面的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return NewInfoDal.GetRecordCount();
        }



        /// <summary>
        /// 根据id查询记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetEntityModel(int id)
        {
            return NewInfoDal.GetEntityModel(id);
        }



        /// <summary>
        /// 根据id删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteNewInfo(int id)
        {
            return NewInfoDal.DeleteNewInfo(id) > 0;
        }


        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool AddNewInfo(News newInfo)
        {
            return NewInfoDal.AddNewInfo(newInfo) > 0;
        }

        public bool UpdateNewInfo(News newInfo)
        {
            return NewInfoDal.UpdateNewInfo(newInfo) > 0;
        }
    }
}
