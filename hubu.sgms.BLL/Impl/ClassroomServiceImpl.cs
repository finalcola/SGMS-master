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
   public  class ClassroomServiceImpl:IClassroomService
    {
        private IClassroomDAL ClassroomDAL = new ClassroomDALImpl();

        public IList<Classroom> SelClassroomByBuilding(string Building)
        {
            return ClassroomDAL.SelClassroomByBuilding(Building);
        }

        public Classroom SelClassroomByClassroomId(string ClassroomId)
        {
            return ClassroomDAL.SelClassroomByClassroomId(ClassroomId);
        }
    }
}
