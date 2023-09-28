using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.DataAccessLayer
{
    [Table("StudentMarks_Table")]
    public class StudentMarksEntity
    {

        
            [Column("SM_Id")]
            public int StudentMarksId { get; set; }
            [Column("SM_Marks")]

            public decimal StudentMarks { get; set; }
            [Column("SM_Grade")]
            public string StudentMarksGrade { get; set; }
            [Column("CL_Id")]
            [ForeignKey("Class")]
            public int ClassId { get; set; }
            public virtual ClassEntity Class { get; set; }

        
    }
}
