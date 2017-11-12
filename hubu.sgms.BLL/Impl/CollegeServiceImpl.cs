using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;

namespace hubu.sgms.BLL.Impl
{
   public  class CollegeServiceImpl:ICollegeService{

        private ICollegeDAL collegeDAL = new CollegeDALImpl();

        public College SelCollegeById(string id)
        {
           return collegeDAL.SelCollegeById(id);
        }

        public IList<College> SelCollegeforArrangeCourse()
        {
            return collegeDAL.SelCollegeforArrangeCourse();
        }
    }
}
