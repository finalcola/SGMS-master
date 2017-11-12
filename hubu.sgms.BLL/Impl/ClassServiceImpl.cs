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
    public class ClassServiceImpl : IClassService
    {
        private IClassDAL classDAL = new ClassDALImpl();

        public IList<Class> SelClassByMajorId(string MajorId)
        {
            return classDAL.SelClassByMajorId(MajorId);
        }

        public Class SelClassByClassId(string ClassId)
        {
            return classDAL.SelClassByClassId(ClassId);
        }
    }
}
