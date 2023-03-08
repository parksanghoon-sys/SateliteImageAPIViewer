using System.ComponentModel.DataAnnotations;

namespace Musician.MVVM.Models
{
    internal class Performers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string? LastName { get; set; }
        [MaxLength(20)]
        public string? Nickname { get; set; }
        public string? ProfileImagePath { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }
        [MaxLength(30)]
        public string? Email { get; set; }
    }
}
