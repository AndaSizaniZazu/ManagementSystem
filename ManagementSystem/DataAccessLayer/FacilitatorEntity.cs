using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.DataAccessLayer
{
    [Table("Facilitator_Table")]
    public class FacilitatorEntity
    {
        [Key]
        [Column("F_Id")]
        public int FacilitatorId { get; set; }
        [Column("F_FullName")]

        public string FacilitatorFullName { get; set; }
        [Column("F_Email")]

        public string FacilitatorEmail { get; set; }
        [Column("F_CellPhoneNumber")]
        public string FacilitatorPhoneNumber { get; set; }
        [Column("F_Qualification")]
        public string Qualification { get; set; }
        [Column("F_IdNumber")]
        public string FacilitatorIdNumber { get; set; }
        public virtual ICollection<ClassEntity> Class { get; set; }

    }
}
