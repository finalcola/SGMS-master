using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ICollegeDAL
    {
        /// <summary>
        /// 根据学院名查询id
        /// </summary>
        /// <param name="collegeName"></param>
        /// <returns></returns>
        string SelectId(string collegeName);

        /// <summary>
        /// 查询所有学院的信息
        /// </summary>
        /// <returns></returns>
        IList<College> SelectColleges();

        College SelectById(string id);

        IList<College> SelCollegeforArrangeCourse();


        College SelCollegeById(string id);
    }
}
