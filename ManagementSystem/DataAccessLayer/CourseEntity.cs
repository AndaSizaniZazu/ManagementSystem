using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.DataAccessLayer
{
    [Table("Course_Table")]
    public class CourseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("Code")]

        public string? Code { get; set; }

        [Column("Description")]
        public string? Description { get; set; }
        [Column("Credits")]
        public int Credits { get; set; }

    }
}
