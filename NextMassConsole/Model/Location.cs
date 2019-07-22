using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NextMassConsole.Model
{
    [Owned]
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Lattitude { get; set; }
        [Required]
        public string Longitude { get; set; }
    }
}