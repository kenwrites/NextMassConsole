using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    public class Church : IChurch
    {
        public Church()
        {
        }

        public Church(IChurch church)
        {
            this.Coordinates = church.Coordinates;
            this.MassTimes = church.MassTimes;
        }
        public int Id { get; set; }
        [Required]
        public ILocation Coordinates { get; set; }
        public ICollection<IMassTime> MassTimes { get; set; }
        public List<ChurchUser> FavoritedBy { get; set; }
    }
}