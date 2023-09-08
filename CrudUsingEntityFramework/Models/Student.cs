using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingEntityFramework.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Marks { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }

    }
}
