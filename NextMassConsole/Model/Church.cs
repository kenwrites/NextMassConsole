using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    public class Church
    {
        public int Id { get; set; }
        [Required]
        public Location Location { get; set; }
        public List<MassTime> MassTimes { get; set; }
        public List<ChurchUser> FavoritedBy { get; set; }
    }
}