namespace hubu.sgms.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Studentms : DbContext
    {
        public Studentms()
            : base("name=Studentms")
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<College> College { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Course_choosing> Course_choosing { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Teacher_course> Teacher_course { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_id)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_name)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administratort_sex)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_id_card)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_department)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_photo)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_contact)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.administrator_other)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.major_id)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.teacher_name)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_credit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_hour)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_type)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_theory)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_experiment)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_opentime)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_prior)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_photo)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.course_choosing_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.student_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.student_name)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.teacher_course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.cou_course_choosing_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.teacher_name)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.classroom_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.usual_grade)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.test_grade)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.total_grade)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.course_credit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e._class)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<Course_choosing>()
                .HasMany(e => e.Course_choosing1)
                .WithOptional(e => e.Course_choosing2)
                .HasForeignKey(e => e.cou_course_choosing_id);

            modelBuilder.Entity<Login>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.major_id)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.major_name)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Major)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_sex)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_id_card)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_department)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_major)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_grade)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_type)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_address)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_native)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_birthplace)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_photo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_politicsstatus)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_contact)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_family)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_award)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.student_other)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teachert_sex)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_id_card)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_department)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_title)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_native)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_birthplace)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_photo)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_politicsstatus)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_teachingtime)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_contact)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacher_other)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.yuliu3)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.teacher_course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.teacher_name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e._class)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.grade)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.college_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.major)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.major_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.course_credit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.classroom_id)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.yuliu1)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_course>()
                .Property(e => e.yuliu2)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
               .Property(e => e.courseid)
               .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.global_status)
                .IsUnicode(false);
        }
    }
}
