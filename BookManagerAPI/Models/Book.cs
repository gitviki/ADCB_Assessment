using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerAPI.Models
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }

        public int Year { get; set; }

        public string ISBN { get; set; }
    }
}
