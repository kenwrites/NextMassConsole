using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    [Owned]
    public class MassTime : IMassTime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public int Hour { get; set; }
        [Required]
        public int Minute { get; set; }
        public int ChurchId { get; set; }
        [ForeignKey("ChurchId")]
        [Required]
        public Church Church { get; set; }
    }
}