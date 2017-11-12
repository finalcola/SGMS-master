using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.DAL;
using hubu.sgms.Model;

namespace hubu.sgms.BLL
{
    public interface IRoleInfoService
    {
        #region 管理员

        // 添加管理员信息
        //adminID adminName adminSex adminIDCard adminDepartment adminContact adminOther adminStatus
        string AddAdminInfo(string adminID, string adminName, string adminSex,string adminIDCard, 
                            string adminDepartment,string adminContact, string adminOther, int adminStatus);

        // 修改管理员信息
        string UpdateAdminInfo(string adminID, string adminName, string adminSex, string adminIDCard,
                            string adminDepartment, string adminContact, string adminOther, int adminStatus);

        // 通过 ID 查找对应的管理员信息
        Administrator SelectAdministratorByID(string adminID);

        // 条件查找管理员信息
        List<Administrator> SelectAllAdminInfo(string adminName, int adminStatus);

        // 删除管理员
        string DeleteAdmin(string adminID);
        #endregion

        #region 教师
        // 添加教师信息
        // teacherName teacherSex teacherIDCard teacherAge teacherDepartment teacherTitle teacherNative teacherBirthplace teacherPoliticsstatus teacherTeachingtime teacherContact teacherOther teacherStatus
        string AddTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment,
                          string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime,
                          string teacherContact, string teacherOther, int teacherStatus);
        
        // 修改教师信息
        string UpdateTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment,
                          string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime,
                          string teacherContact, string teacherOther, int teacherStatus);
        // 通过 ID 查找对应的教师信息
        Teacher SelectTeacherByID(string teacherID);

        // 通过条件查找教师信息
        List<Teacher> SelectAllTeacherInfo(string teacherName, string teacherDepartment);

        // 通过 ID 删除对应的教师
        string AdminDeleteTeacher(string teacherID);
        #endregion

        #region 学生
        // 添加学生信息
        string UpdateStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor,
                          string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus,
                          string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus);

        // 添加学生信息
        string AddStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor,
                          string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus, 
                          string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus);

        // 通过 ID 查找对应的学生信息
        Student SelectStudent(string studentID);

        // 通过条件查找学生信息
        List<Student> SelectAllStudentInfo(string studentName, string studentDepartment, string studentSex);

        // 通过 ID 删除对应的学生
        string AdminDeleteStudent(string studentID);
        #endregion

    }
}
