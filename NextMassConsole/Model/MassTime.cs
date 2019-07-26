using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    [Owned]
    public class MassTime : IMassTime
    {
        public MassTime(DayOfWeek day, int hour, int minute, IChurch church)
        {
            this.Day = day;

            if (hour <=23 && hour >= 0)
            {
                this.Hour = hour;
            }
            else
            {
                throw new InvalidTimeException($"Hour input {hour} is not valid.  Enter a number between 0 and 23, inclusive.");
            }

            if (minute <= 59 && minute >= 0)
            {
                this.Minute = minute;
            }
            else
            {
                throw new InvalidTimeException($"Minute input {minute} is not valid.  Enter a number between 0 and 23, inclusive.");
            }
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [Required]
        public int Hour { get; set; }
        [Required]
        public int Minute { get; set; }
        public int ChurchId { get; set; }
        [ForeignKey("ChurchId")]
        [Required]
        public IChurch Church { get; set; }

        public DateTime GetNextMass(DateTime now)
        {
            return new DateTime();
        }
        
    }
}