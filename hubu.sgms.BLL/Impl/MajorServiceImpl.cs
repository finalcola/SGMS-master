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
    public class MajorServiceImpl : IMajorService
    {
        private IMajorDAL majorDAL = new MajorDALImpl();

        public IList<Major> SelMajorByCollegeId(string CollegeId)
        {
            return majorDAL.SelMajorByCollegeId(CollegeId);
        }

        public Major SelMajorByMajorId(string MajorId)
        {
            return majorDAL.SelMajorByMajorId(MajorId);
        }
    }
}
