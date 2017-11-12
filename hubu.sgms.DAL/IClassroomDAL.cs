using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface IClassroomDAL
    {
        IList<Classroom> SelClassroomByBuilding(string Building);

        Classroom SelClassroomByClassroomId(string ClassroomId);
    }
}
