using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.DAL;
using hubu.sgms.Model;
using hubu.sgms.DAL.Impl;

namespace hubu.sgms.BLL.Impl
{
    public class RoleInfoServiceImpl : IRoleInfoService
    {
        private IRoleInfoDAL roleDAL = new RoleDALImpl();
        #region 管理员角色
        // 添加管理员信息
        public string AddAdminInfo(string adminID, string adminName, string adminSex, string adminIDCard, string adminDepartment, string adminContact, string adminOther, int adminStatus)
        {
            return roleDAL.AddAdminInfo(adminID, adminName, adminSex, adminIDCard, adminDepartment, adminContact, adminOther, adminStatus);
        }

        // 修改管理员信息
        public string UpdateAdminInfo(string adminID, string adminName, string adminSex, string adminIDCard, string adminDepartment, string adminContact, string adminOther, int adminStatus)
        {
            return roleDAL.UpdateAdminInfo(adminID, adminName, adminSex, adminIDCard, adminDepartment, adminContact, adminOther, adminStatus);
        }

        // 通过 ID 查找对应的管理员信息
        public Administrator SelectAdministratorByID(string adminID)
        {
            Administrator administrator = roleDAL.SelectAdministratorByID(adminID);
            return administrator;
        }

        // 条件查找管理员信息
        public List<Administrator> SelectAllAdminInfo(string adminName, int adminStatus)
        {
            return roleDAL.SelectAllAdminInfo(adminName, adminStatus);
        }

        // 删除管理员
        public string DeleteAdmin(string adminID)
        {
            return roleDAL.DeleteAdmin(adminID);
        }
        #endregion

        #region  教师角色
        // 添加教师信息
        public string AddTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment, string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime, string teacherContact, string teacherOther, int teacherStatus)
        {
            return roleDAL.AddTeacherInfo(teacherID, teacherName, teacherSex, teacherIDCard, teacherAge, teacherDepartment, teacherTitle, teacherNative, teacherBirthplace, teacherPoliticsstatus, teacherTeachingtime, teacherContact, teacherOther, teacherStatus);
        }

        // 修改教师信息
        public string UpdateTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment, string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime, string teacherContact, string teacherOther, int teacherStatus)
        {
            return roleDAL.UpdateTeacherInfo(teacherID, teacherName, teacherSex, teacherIDCard, teacherAge, teacherDepartment, teacherTitle, teacherNative, teacherBirthplace, teacherPoliticsstatus, teacherTeachingtime, teacherContact, teacherOther, teacherStatus);
        }

        // 通过 ID 查找对应的教师信息
        public Teacher SelectTeacherByID(string teacherID)
        {
            Teacher teacher = roleDAL.SelectTeacherByID(teacherID);
            return teacher;
        }

        // 通过条件查找教师信息
        public List<Teacher> SelectAllTeacherInfo(string teacherName, string teacherDepartment)
        {
            return roleDAL.SelectAllTeacherInfo(teacherName, teacherDepartment);
        }

        // 通过 ID 删除对应的教师
        public string AdminDeleteTeacher(string teacherID)
        {
            return roleDAL.AdminDeleteTeacher(teacherID);
        }
        #endregion

        #region 学生角色
        // 添加学生信息
        public string AddStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor, string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus, string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus)
        {
            return roleDAL.AddStudentInfo(studentID, studentName, studentSex, studentIDCard, studentAge, studentDepartment, studentMajor, studentGrade, studentType, studentAddress, studentNative, studentBirthplace, studentPoliticsstatus, studentContact, studentFamily, studentAward, studentOther, studentStatus);
        }
        
        // 修改学生信息
        public string UpdateStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor, string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus, string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus)
        {
            return roleDAL.UpdateStudentInfo(studentID, studentName, studentSex, studentIDCard, studentAge, studentDepartment, studentMajor, studentGrade, studentType, studentAddress, studentNative, studentBirthplace, studentPoliticsstatus, studentContact, studentFamily, studentAward, studentOther, studentStatus);
        }
        
        //  查询学生信息
        public Student SelectStudent(string studentID)
        {
            Student student = roleDAL.SelectStudent(studentID);
            return student;
        }

        // 通过条件查找学生信息
        public List<Student> SelectAllStudentInfo(string studentName, string studentDepartment, string studentSex)
        {
            return roleDAL.SelectAllStudentInfo(studentName, studentDepartment, studentSex);
        }

        // 通过 ID 删除对应的学生
        public string AdminDeleteStudent(string studentID)
        {
            return roleDAL.AdminDeleteStudent(studentID);
        }
        #endregion
    }
}
