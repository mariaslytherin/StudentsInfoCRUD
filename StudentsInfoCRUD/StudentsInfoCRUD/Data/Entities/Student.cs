using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsInfoCRUD.Data.Entities
{
    public class Student
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FacultyNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string Faculty { get; set; }
    }
}
