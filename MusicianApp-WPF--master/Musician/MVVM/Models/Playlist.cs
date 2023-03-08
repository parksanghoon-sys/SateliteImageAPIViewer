using System.ComponentModel.DataAnnotations;

namespace Musician.MVVM.Models
{
    internal class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string PlaylistName { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        [MaxLength(50)]
        public string Creator { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
