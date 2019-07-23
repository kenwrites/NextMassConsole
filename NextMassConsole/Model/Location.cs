using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NextMassConsole.Model
{
    [Owned]
    public class Location : ILocation
    {
        public Location(ILocation location)
        {
            this.Lattitude = location.Lattitude;
            this.Longitude = location.Longitude;
        }

        public Location(string lattitude, string longitude)
        {
            // check if can parse
            double parsedLat = 0.0;
            bool LatIsValid = double.TryParse(lattitude, out parsedLat);

            // check if in range
            LatIsValid =
                (parsedLat < -90.0 || parsedLat > 90.0) ? false : LatIsValid;

            if (LatIsValid)
            {
                this.Lattitude = parsedLat;
            }
            else
            {
                throw new InvalidLatOrLongException($"Lattitude {lattitude} could not be parsed by double.TryParse.");
            }

            
            double parsedLong = 0.0;
            bool LongIsValid = double.TryParse(longitude, out parsedLong);

            LongIsValid =
                (parsedLong < -180.0 || parsedLong > 180.0) ? false : LongIsValid;
            if (LongIsValid)
            {
                this.Longitude = parsedLong;
            }
            else
            {
                throw new InvalidLatOrLongException($"Longitude {longitude} could not be parsed by double.TryParse.");
            }
        }

        public int Id { get; set; }
        [Required]
        public double Lattitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}