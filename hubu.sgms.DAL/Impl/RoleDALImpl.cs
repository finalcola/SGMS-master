using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using System.Data.SqlClient;
using System.Data;

namespace hubu.sgms.DAL.Impl
{
    public class RoleDALImpl : IRoleInfoDAL
    {
        // 添加管理员信息
        public string AddAdminInfo(string adminID, string adminName, string adminSex, string adminIDCard, string adminDepartment, string adminContact, string adminOther, int adminStatus)
        {
            string sql = "Insert into Administrator(administrator_id,administrator_name,administratort_sex,administrator_id_card,administrator_department,administrator_contact,administrator_other,status)values" +
                                                    "(@adminID, @adminName, @adminSex, @adminIDCard, @adminDepartment,@adminContact, @adminOther, @adminStatus)";
            //adminID adminName adminSex adminIDCard adminDepartment adminContact adminOther adminStatus
            SqlParameter[] parameters = {
                new SqlParameter("@adminID",adminID),
                new SqlParameter("@adminName",adminName),
                new SqlParameter("@adminSex",adminSex),
                new SqlParameter("@adminIDCard",adminIDCard),
                new SqlParameter("@adminDepartment",adminDepartment),
                new SqlParameter("@adminContact",adminContact),
                new SqlParameter("@adminOther",adminOther),
                new SqlParameter("@adminStatus",adminStatus)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功添加" + count + "个管理员信息";
            return succeed;
        }

        // 添加教师员信息
        public string AddTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment, string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime, string teacherContact, string teacherOther, int teacherStatus)
        {
            string sql = "Insert into Teacher(teacher_id,teacher_name,teachert_sex,teacher_id_card,teachert_age,teacher_department,teacher_title,teacher_native,teacher_birthplace,teacher_politicsstatus,teacher_teachingtime,teacher_contact,teacher_other,status)values" +
                                            "(@teacherID,@teacherName,@teacherSex,@teacherIDCard,@teacherAge,@teacherDepartment,@teacherTitle,@teacherNative,@teacherBirthplace,@teacherPoliticsstatus,@teacherTeachingtime,@teacherContact,@teacherOther,@teacherStatus)";
            // teacherID teacherName teacherSex teacherIDCard teacherAge teacherDepartment teacherTitle teacherNative teacherBirthplace 
            // teacherPoliticsstatus teacherTeachingtime teacherContact teacherOther teacherStatus
            SqlParameter[] parameters = {
                new SqlParameter("@teacherID",teacherID),
                new SqlParameter("@teacherName",teacherName),
                new SqlParameter("@teacherSex",teacherSex),
                new SqlParameter("@teacherIDCard",teacherIDCard),
                new SqlParameter("@teacherAge",teacherAge),
                new SqlParameter("@teacherDepartment",teacherDepartment),
                new SqlParameter("@teacherTitle",teacherTitle),
                new SqlParameter("@teacherNative",teacherNative),
                new SqlParameter("@teacherBirthplace",teacherBirthplace),
                new SqlParameter("@teacherPoliticsstatus",teacherPoliticsstatus),
                new SqlParameter("@teacherTeachingtime",teacherTeachingtime),
                new SqlParameter("@teacherContact",teacherContact),
                new SqlParameter("@teacherOther",teacherOther),
                new SqlParameter("@teacherStatus",teacherStatus)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功添加" + count + "个教师信息";
            return succeed;

        }

        // 添加学生信息
        public string AddStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor, string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus, string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus,string studentClass)
        {
            string sql = "Insert into Student(student_id,student_name,student_sex,student_age,student_id_card,student_department,student_major,student_grade,student_type,student_address,student_native,student_birthplace,student_politicsstatus,student_contact,student_family,student_award,student_other,status,class_id,college_id)values" +
                                            "(@studentID,@studentName,@studentSex,@studentAge,@studentIDCard,(select name from College where college_id=@studentDepartment)," +
                                                                                                                               "(select major_name from Major where major_id =@studentMajor)," +
                                                                                                                                             "@studentGrade,@studentType,@studentAddress,@studentNative,@studentBirthplace,@studentPoliticsstatus,@studentContact,@studentFamily,@studentAward,@studentOther,@studentStatus,@studentClass,@studentDepartment)";
            SqlParameter[] parameters = {
                new SqlParameter("@studentID",studentID),
                new SqlParameter("@studentName",studentName),
                new SqlParameter("@studentSex",studentSex),
                new SqlParameter("@studentIDCard",studentIDCard),
                new SqlParameter("@studentAge",studentAge),
                new SqlParameter("@studentDepartment",studentDepartment),
                new SqlParameter("@studentMajor",studentMajor),
                new SqlParameter("@studentGrade",studentGrade),
                new SqlParameter("@studentType",studentType),
                new SqlParameter("@studentAddress",studentAddress),
                new SqlParameter("@studentNative",studentNative),
                new SqlParameter("@studentBirthplace",studentBirthplace),
                new SqlParameter("@studentPoliticsstatus",studentPoliticsstatus),
                new SqlParameter("@studentContact",studentContact),
                new SqlParameter("@studentFamily",studentFamily),
                new SqlParameter("@studentAward",studentAward),
                new SqlParameter("@studentOther",studentOther),
                new SqlParameter("@studentStatus",studentStatus),
                new SqlParameter("@studentClass",studentClass)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功添加" + count + "个学生信息";
            return succeed;
        }

       

        // 修改管理员信息
        public string UpdateAdminInfo(string adminID, string adminName, string adminSex, string adminIDCard, string adminDepartment, string adminContact, string adminOther, int adminStatus)
        {
            string sql = "update Administrator set administrator_name=@adminName,administratort_sex=@adminSex,administrator_id_card=@adminIDCard," +
                "administrator_department=@adminDepartment,administrator_contact=@adminContact,administrator_other=@adminOther,status=@adminStatus " +
                "where administrator_id = @adminID";
            SqlParameter[] parameters = {
                new SqlParameter("@adminID",adminID),
                new SqlParameter("@adminName",adminName),
                new SqlParameter("@adminSex",adminSex),
                new SqlParameter("@adminIDCard",adminIDCard),
                new SqlParameter("@adminDepartment",adminDepartment),
                new SqlParameter("@adminContact",adminContact),
                new SqlParameter("@adminOther",adminOther),
                new SqlParameter("@adminStatus",adminStatus)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功修改" + count + "个管理员信息";
            return succeed;
        }

        // 修改教师信息
        public string UpdateTeacherInfo(string teacherID, string teacherName, string teacherSex, string teacherIDCard, int teacherAge, string teacherDepartment, string teacherTitle, string teacherNative, string teacherBirthplace, string teacherPoliticsstatus, string teacherTeachingtime, string teacherContact, string teacherOther, int teacherStatus)
        {
            string sql = "update Teacher set teacher_name=@teacherName, teachert_sex=@teacherSex, teacher_id_card=@teacherIDCard, teachert_age=@teacherAge," +
                        "teacher_department=@teacherDepartment,teacher_title=@teacherTitle,teacher_native=@teacherNative,teacher_birthplace=@teacherBirthplace,teacher_politicsstatus=@teacherPoliticsstatus," +
                        "teacher_teachingtime=@teacherTeachingtime,teacher_contact=@teacherContact,teacher_other=@teacherOther,status=@teacherStatus where teacher_id = @teacherID";
            SqlParameter[] parameters = {
                new SqlParameter("@teacherID",teacherID),
                new SqlParameter("@teacherName",teacherName),
                new SqlParameter("@teacherSex",teacherSex),
                new SqlParameter("@teacherIDCard",teacherIDCard),
                new SqlParameter("@teacherAge",teacherAge),
                new SqlParameter("@teacherDepartment",teacherDepartment),
                new SqlParameter("@teacherTitle",teacherTitle),
                new SqlParameter("@teacherNative",teacherNative),
                new SqlParameter("@teacherBirthplace",teacherBirthplace),
                new SqlParameter("@teacherPoliticsstatus",teacherPoliticsstatus),
                new SqlParameter("@teacherTeachingtime",teacherTeachingtime),
                new SqlParameter("@teacherContact",teacherContact),
                new SqlParameter("@teacherOther",teacherOther),
                new SqlParameter("@teacherStatus",teacherStatus)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功修改" + count + "个教师信息";
            return succeed;
        }

        // 修改学生信息
        public string UpdateStudentInfo(string studentID, string studentName, string studentSex, string studentIDCard, int studentAge, string studentDepartment, string studentMajor, string studentGrade, string studentType, string studentAddress, string studentNative, string studentBirthplace, string studentPoliticsstatus, string studentContact, string studentFamily, string studentAward, string studentOther, int studentStatus)
        {
            string sql = "update Student set student_name=@studentName,student_sex=@studentSex,student_age=@studentAge,student_id_card=@studentIDCard,student_department=@studentDepartment,student_major=@studentMajor," +
                "student_grade=@studentGrade,student_type=@studentType,student_address=@studentAddress,student_native=@studentNative,student_birthplace=@studentBirthplace,student_politicsstatus=@studentPoliticsstatus," +
                "student_contact=@studentContact,student_family=@studentFamily,student_award=@studentAward,student_other=@studentOther,status=@studentStatus where student_id=@studentID";
            SqlParameter[] parameters = {
                new SqlParameter("@studentID",studentID),
                new SqlParameter("@studentName",studentName),
                new SqlParameter("@studentSex",studentSex),
                new SqlParameter("@studentIDCard",studentIDCard),
                new SqlParameter("@studentAge",studentAge),
                new SqlParameter("@studentDepartment",studentDepartment),
                new SqlParameter("@studentMajor",studentMajor),
                new SqlParameter("@studentGrade",studentGrade),
                new SqlParameter("@studentType",studentType),
                new SqlParameter("@studentAddress",studentAddress),
                new SqlParameter("@studentNative",studentNative),
                new SqlParameter("@studentBirthplace",studentBirthplace),
                new SqlParameter("@studentPoliticsstatus",studentPoliticsstatus),
                new SqlParameter("@studentContact",studentContact),
                new SqlParameter("@studentFamily",studentFamily),
                new SqlParameter("@studentAward",studentAward),
                new SqlParameter("@studentOther",studentOther),
                new SqlParameter("@studentStatus",studentStatus)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功修改" + count + "个学生信息";
            return succeed;
        }




        // 通过 ID 查找对应的管理员信息
        Administrator IRoleInfoDAL.SelectAdministratorByID(string adminID)
        {
            string sql = "select * from Administrator where administrator_id = @adminID";
            SqlParameter[] parameters = {
                new SqlParameter("@adminID",adminID)
            };

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            
            Administrator administrator = new Administrator();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];

                administrator.administrator_id = dataRow["administrator_id"].ToString();
                administrator.administrator_name = dataRow["administrator_name"].ToString();
                administrator.administratort_sex = dataRow["administratort_sex"].ToString();
                administrator.administrator_id_card = dataRow["administrator_id_card"].ToString();
                administrator.administrator_department = dataRow["administrator_department"].ToString();
                administrator.administrator_photo = dataRow["administrator_photo"].ToString();
                administrator.administrator_contact = dataRow["administrator_contact"].ToString();
                administrator.administrator_other = dataRow["administrator_other"].ToString();
                administrator.status = Int32.Parse(dataRow["status"].ToString());
            }

            return administrator;
        }

        // 通过条件查找管理员信息
        public List<Administrator> SelectAllAdminInfo(string adminName, string adminDepartment)
        {
            string sqlNull = "2b婿s1jHh子1hl91";
            string sql = "select * from Administrator";
            
            if (adminName == sqlNull && adminDepartment == sqlNull)  //都没有输入
            {
                sql = "select * from Administrator where administrator_name=@adminName and administrator_department=@adminDepartment or 1=1";
            }
            else if (adminName == sqlNull && adminDepartment != sqlNull)     //只输入院系
            {
                sql = "select * from Administrator where (administrator_name=@adminName or 1=1) and administrator_department=@adminDepartment";
            }
            else if (adminName != sqlNull && adminDepartment == sqlNull) //只输入姓名
            {
                sql = "select * from Administrator where administrator_name like @adminName and (administrator_department=@adminDepartment or 1=1)";
                adminName = "%" + adminName + "%";
            }
            else if(adminName != sqlNull && adminDepartment == sqlNull)  //都输入了
            {
                sql = "select * from Administrator where administrator_name like @adminName and administrator_department=@adminDepartment";
                adminName = "%" + adminName + "%";
            }

            SqlParameter[] parameters = {
                new SqlParameter("@adminName",adminName),
                new SqlParameter("@adminDepartment",adminDepartment)
            };
            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            //存放结果
            List<Administrator> administratorList = new List<Administrator>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Administrator administrator = new Administrator();

                administrator.administrator_id = dataRow["administrator_id"].ToString();
                administrator.administrator_name = dataRow["administrator_name"].ToString();
                administrator.administratort_sex = dataRow["administratort_sex"].ToString();
                administrator.administrator_id_card = dataRow["administrator_id_card"].ToString();
                administrator.administrator_department = dataRow["administrator_department"].ToString();
                administrator.administrator_photo = dataRow["administrator_photo"].ToString();
                administrator.administrator_contact = dataRow["administrator_contact"].ToString();
                administrator.administrator_other = dataRow["administrator_other"].ToString();
                administrator.status = Int32.Parse(dataRow["status"].ToString());

                administratorList.Add(administrator);

            }
            return administratorList;
        }

        // 删除管理员
        public string DeleteAdmin(string adminID)
        {
            string sql = "delete from Administrator where administrator_id = @adminID";
            SqlParameter[] parameters = {
                new SqlParameter("@adminID",adminID)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功删除" + count + "个管理员信息";
            return succeed;
        }


        // 通过 ID 查找对应的教师信息
        Teacher IRoleInfoDAL.SelectTeacherByID(string teacherID)
        {
            string sql = "select * from Teacher where teacher_id = @teacherID";
            SqlParameter[] parameter = {
                new SqlParameter("@teacherID",teacherID)
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameter);

            Teacher teacher = new Teacher();
            if(dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];

                teacher.teacher_id = dataRow["teacher_id"].ToString();
                teacher.teacher_name = dataRow["teacher_name"].ToString();
                teacher.teachert_sex = dataRow["teachert_sex"].ToString();
                teacher.teacher_id_card = dataRow["teacher_id_card"].ToString();
                teacher.teachert_age = Int32.Parse(dataRow["teachert_age"].ToString());
                teacher.teacher_department = dataRow["teacher_department"].ToString();
                teacher.teacher_title = dataRow["teacher_title"].ToString();
                teacher.teacher_native = dataRow["teacher_native"].ToString();
                teacher.teacher_birthplace = dataRow["teacher_birthplace"].ToString();
                teacher.teacher_photo = dataRow["teacher_photo"].ToString();
                teacher.teacher_politicsstatus = dataRow["teacher_politicsstatus"].ToString();
                teacher.teacher_teachingtime = dataRow["teacher_teachingtime"].ToString();
                teacher.teacher_contact = dataRow["teacher_contact"].ToString();
                teacher.teacher_other = dataRow["teacher_other"].ToString();
                teacher.status = Int32.Parse(dataRow["status"].ToString());

            }
            return teacher;
        }

        // 通过条件查找教师信息
        public List<Teacher> SelectAllTeacherInfo(string teacherName, string teacherDepartment)
        {
            string sql = "select * from Teacher";
            if (teacherName == "2b婿s1jHh子1hl91" && teacherDepartment == "2b婿s1jHh子1hl91")
            {
                sql = "select * from Teacher where teacher_name=@teacherName and teacher_department=@teacherDepartment or 1=1";
            }
            else if (teacherName == "2b婿s1jHh子1hl91" && teacherDepartment != "2b婿s1jHh子1hl91")
            {
                sql = "select * from Teacher where (teacher_name=@teacherName or 1=1) and teacher_department=@teacherDepartment";
            }
            else if (teacherName != "2b婿s1jHh子1hl91" && teacherDepartment == "2b婿s1jHh子1hl91")
            {
                sql = "select * from Teacher where teacher_name like @teacherName and (teacher_department=@teacherDepartment or 1=1)";
                teacherName = "%" + teacherName + "%";
            }
            else if (teacherName != "2b婿s1jHh子1hl91" && teacherDepartment != "2b婿s1jHh子1hl91")
            {
                sql = "select * from Teacher where teacher_name like @teacherName and teacher_department=@teacherDepartment";
                teacherName = "%" + teacherName + "%";
            }
            SqlParameter[] parameters = {
                new SqlParameter("@teacherName",teacherName),
                new SqlParameter("@teacherDepartment",teacherDepartment)
            };
            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            //存放结果
            List<Teacher> teacherList = new List<Teacher>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Teacher teacher = new Teacher();

                teacher.teacher_id = dataRow["teacher_id"].ToString();
                teacher.teacher_name = dataRow["teacher_name"].ToString();
                teacher.teachert_sex = dataRow["teachert_sex"].ToString();
                teacher.teacher_id_card = dataRow["teacher_id_card"].ToString();
                teacher.teachert_age = Int32.Parse(dataRow["teachert_age"].ToString());
                teacher.teacher_department = dataRow["teacher_department"].ToString();
                teacher.teacher_title = dataRow["teacher_title"].ToString();
                teacher.teacher_native = dataRow["teacher_native"].ToString();
                teacher.teacher_birthplace = dataRow["teacher_birthplace"].ToString();
                teacher.teacher_photo = dataRow["teacher_photo"].ToString();
                teacher.teacher_politicsstatus = dataRow["teacher_politicsstatus"].ToString();
                teacher.teacher_teachingtime = dataRow["teacher_teachingtime"].ToString();
                teacher.teacher_contact = dataRow["teacher_contact"].ToString();
                teacher.teacher_other = dataRow["teacher_other"].ToString();
                teacher.status = Int32.Parse(dataRow["status"].ToString());

                teacherList.Add(teacher);

            }
            return teacherList;
        }
        
        // 通过 ID 删除对应的教师
        public string AdminDeleteTeacher(string teacherID)
        {
            string sql = "delete from Teacher where teacher_id = @teacherID";

            SqlParameter[] parameters = {
                new SqlParameter("@teacherID",teacherID)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功删除" + count + "个教师信息";
            return succeed;
        }




        // 通过 ID 查找对应的学生信息
        Student IRoleInfoDAL.SelectStudent(string studentID)
        {
            string sql = "select * from Student where student_id = @studentID";
            SqlParameter[] parameter = {
                new SqlParameter("@studentID",studentID)
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameter);

            Student student = new Student();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];

                student.student_id = dataRow["student_id"].ToString();
                student.student_name = dataRow["student_name"].ToString();
                student.student_sex = dataRow["student_sex"].ToString();
                student.student_age = Int32.Parse(dataRow["student_age"].ToString());
                student.student_id_card = dataRow["student_id_card"].ToString();
                student.student_department = dataRow["student_department"].ToString();
                student.student_major = dataRow["student_major"].ToString();
                student.student_grade = dataRow["student_grade"].ToString();
                student.student_type = dataRow["student_type"].ToString();
                student.student_address = dataRow["student_address"].ToString();
                student.student_native = dataRow["student_native"].ToString();
                student.student_birthplace = dataRow["student_birthplace"].ToString();
                student.student_politicsstatus = dataRow["student_politicsstatus"].ToString();
                student.student_contact = dataRow["student_contact"].ToString();
                student.student_family = dataRow["student_family"].ToString();
                student.student_award = dataRow["student_award"].ToString();
                student.student_other = dataRow["student_other"].ToString();
                student.status = Int32.Parse(dataRow["status"].ToString());

            }
            return student;
        }

        // 通过条件查找学生信息
        public List<Student> SelectAllStudentInfo(string studentName, string studentDepartment, string studentMajor, string studentClass)
        {
            string sqlNull = "2b婿s1jHh子1hl91";
            string sql = "select * from Student";

            if (studentDepartment != sqlNull && studentMajor == sqlNull && studentName == sqlNull)   //只输入学院信息
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor) or 1=1)and" +
                    "(class_id=@studentClass or 1=1) and (student_name=@studentName or 1=1)";
            }
            if (studentMajor != sqlNull && studentClass == sqlNull && studentName == sqlNull)   //只输入学院，专业
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor)) and" +
                    "(class_id=@studentClass or 1=1) and (student_name=@studentName or 1=1)";
            }
            if (studentClass != sqlNull && studentName == sqlNull)   //只输入学院，专业，班级
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor)) and" +
                    "(class_id=@studentClass) and (student_name=@studentName or 1=1)";
            }
            if (studentDepartment == sqlNull && studentName != sqlNull)   //只输入姓名
            {
                sql = "select * from Student where (college_id=@studentDepartment or 1=1) and (student_major=(select major_name from Major where major_id=@studentMajor) or 1=1) and" +
                    "(class_id=@studentClass or 1=1) and (student_name like @studentName)";
                studentName = "%" + studentName + "%";
            }
            if (studentDepartment != sqlNull && studentMajor == sqlNull && studentName != sqlNull)   //只输入学院，姓名
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor) or 1=1) and" +
                    "(class_id=@studentClass or 1=1) and (student_name like @studentName)";
                studentName = "%" + studentName + "%";
            }
            if (studentMajor != sqlNull && studentClass == sqlNull && studentName != sqlNull)   //只输入学院，专业，姓名
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor)) and" +
                    "(class_id=@studentClass or 1=1) and (student_name like @studentName)";
                studentName = "%" + studentName + "%";
            }
            if (studentClass != sqlNull && studentName != sqlNull)  //都输入了
            {
                sql = "select * from Student where (college_id=@studentDepartment) and (student_major=(select major_name from Major where major_id=@studentMajor)) and" +
                    "(class_id=@studentClass) and (student_name like @studentName)";
                studentName = "%" + studentName + "%";
            }

            SqlParameter[] parameter = {
                new SqlParameter("@studentDepartment",studentDepartment),
                new SqlParameter("@studentMajor",studentMajor),
                new SqlParameter("@studentClass",studentClass),
                new SqlParameter("@studentName",studentName)
            };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameter);
            List<Student> studentList = new List<Student>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Student student = new Student();

                student.student_id = dataRow["student_id"].ToString();
                student.student_name = dataRow["student_name"].ToString();
                student.student_sex = dataRow["student_sex"].ToString();
                student.student_age = Int32.Parse(dataRow["student_age"].ToString());
                student.student_id_card = dataRow["student_id_card"].ToString();
                student.student_department = dataRow["student_department"].ToString();
                student.student_major = dataRow["student_major"].ToString();
                student.student_grade = dataRow["student_grade"].ToString();
                student.student_type = dataRow["student_type"].ToString();
                student.student_address = dataRow["student_address"].ToString();
                student.student_native = dataRow["student_native"].ToString();
                student.student_birthplace = dataRow["student_birthplace"].ToString();
                student.student_politicsstatus = dataRow["student_politicsstatus"].ToString();
                student.student_contact = dataRow["student_contact"].ToString();
                student.student_family = dataRow["student_family"].ToString();
                student.student_award = dataRow["student_award"].ToString();
                student.student_other = dataRow["student_other"].ToString();
                student.status = Int32.Parse(dataRow["status"].ToString());

                studentList.Add(student);

            }
            return studentList;
        }

        // 通过 ID 删除对应的学生
        public string AdminDeleteStudent(string studentID)
        {
            string sql = "delete from Student where student_id = @studentID";
            SqlParameter[] parameters = {
                new SqlParameter("@studentID",studentID)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);

            string succeed = "成功删除" + count + "个学生信息";
            return succeed;
        }
    }
}
