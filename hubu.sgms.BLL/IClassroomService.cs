using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface IClassroomService
    {
        IList<Classroom> SelClassroomByBuilding(string Building);

        Classroom SelClassroomByClassroomId(string ClassroomId);
    }
}
