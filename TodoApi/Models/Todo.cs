using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Todo")]
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Title",TypeName ="varchar(200)")]
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }
        [Column("Description", TypeName = "text")]
        [Required]
        public string Description { get; set; }


    }
}
