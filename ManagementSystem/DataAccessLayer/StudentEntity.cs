using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagementSystem.DataAccessLayer
{
    [Table("Student_Table")]
    public class StudentEntity
    {
        [Key]
        [Column("S_Id")]
        public int StudentId { get; set; }

        [Column("S_FullName")]

        public string FullName { get; set; }
        [Column("S_Email")]

        public string StudentEmail { get; set; }
        [Column("S_PhoneNumber")]
        public string StudentPhoneNumber { get; set; }
        [Column("S_EnrollmentDate")]
        public DateTime? EnrollmentDate { get; set; }

        [Column("Id")]
        [ForeignKey("Course")]
        public int Id { get; set; }
        public virtual CourseEntity Course { get; set; }


    }
}
