using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.DataAccessLayer
{
    [Table("Class_Table")]
    public class ClassEntity
    {
            [Column("CL_Id")]
            public int ClassId { get; set; }

            [Column("CL_Name")]
            public string? ClassName { get; set; }

            [Column("Id")]
         
            public int Id { get; set; }

            [Column("F_Id")]
            
            public int FacilitatorId { get; set; }

            public virtual CourseEntity Course { get; set; }
            public virtual FacilitatorEntity Facilitator { get; set; }
            



    }
}
