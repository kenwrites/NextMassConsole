using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    [Owned]
    public class Location : ILocation
    {
        public Location()
        {
        }
        public Location(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public Location(ILocation location)
        {
            this.Latitude = location.Latitude;
            this.Longitude = location.Longitude;
        }

        public Location(string latitude, string longitude)
        {
            // check if can parse
            double parsedLat = 0.0;
            bool LatIsValid = double.TryParse(latitude, out parsedLat);

            // check if in range
            LatIsValid =
                (parsedLat < -90.0 || parsedLat > 90.0) ? false : LatIsValid;

            if (LatIsValid)
            {
                this.Latitude = parsedLat;
            }
            else
            {
                throw new InvalidLatOrLongException($"Latitude {latitude} could not be parsed by double.TryParse.");
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
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}