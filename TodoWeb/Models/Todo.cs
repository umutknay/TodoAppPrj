using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWeb.Models
{
    [Table("Todo")]
    public class Todo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Title",TypeName ="nvarchar(200)")]
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [Column("Description", TypeName = "nText")]
        [Required]
        public string Description { get; set; }


    }
}
