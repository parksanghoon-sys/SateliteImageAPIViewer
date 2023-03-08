using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.MVVM.Models
{
    internal class Music
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Column(TypeName = "DateTime")]
        public string Time { get; set; }
    }
}
