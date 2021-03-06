﻿using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface ITeacher_CourseService
    {
        int AddTeacher_Course(string course_id, string teacher_id, string class_id);
        IList<Teacher_course> SelTeacher_CourseByDetail(string course_id, string teacher_id, string class_id);
    }
}
