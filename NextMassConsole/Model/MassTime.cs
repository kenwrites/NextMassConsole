using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    [Owned]
    public class MassTime : IMassTime
    {        
        public MassTime()
        {
        }
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
                throw new InvalidTimeException($"Minute input {minute} is not valid.  Enter a number between 0 and 59, inclusive.");
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

        /// <summary>
        /// Given a DateTime which represents the present, this method finds the next Mass time in the future.
        /// </summary>
        /// <param name="now">Represents the present moment.</param>
        /// <returns>A DateTime which represents the next occurence of this regularly scheduled Mass.</returns>
        public DateTime GetNextMass(DateTime now)
        {
            // TODO:  Refactor this method so that it uses a custom class to iterate through possible dates and times.  Using DateTime is inefficient and cumbersome, as the relevant fields on DateTime are read-only.  

            bool timeNotFound = true;
            DateTime dateToTest = now;

            while (timeNotFound)
            {
                // Test and assign DayOfWeek
                if (dateToTest.DayOfWeek < this.Day)
                {
                    var daysToMass = (int)this.Day - (int)dateToTest.DayOfWeek;
                    dateToTest = ResetTimeValues(dateToTest);
                    dateToTest = dateToTest.AddDays(daysToMass);
                }
                if (dateToTest.DayOfWeek == this.Day)
                {
                    // Test and assign Hour
                    if (dateToTest.Hour < this.Hour)
                    {
                        dateToTest = UpdateHour(this.Hour, dateToTest);
                        dateToTest = ResetTimeValues(dateToTest, resetHour: false);
                    }
                    if (dateToTest.Hour == this.Hour)
                    {

                        // Test and assign Minute
                        if (dateToTest.Minute < this.Minute)
                        {
                            dateToTest = ResetTimeValues(dateToTest, resetHour: false, resetMinute: false);
                            dateToTest = UpdateMinute(this.Minute, dateToTest);
                        }

                        if (dateToTest.Minute == this.Minute)
                        {
                            // Time found.  Declare time found and break loop.
                            timeNotFound = false;
                            break;
                        }

                        // Since Mass time is in past today, advance to midnight and begin again.
                        dateToTest = ResetTimeValues(dateToTest);
                        dateToTest = dateToTest.AddDays(1);
                        break;

                    } // end Hour checks

                      // Since Mass time is in past today, advance to midnight and begin again.
                    dateToTest = ResetTimeValues(dateToTest);
                    dateToTest = dateToTest.AddDays(1);
                    break;

                } // end DayOfWeek checks

                // Since Mass is in the past this week, advance to midnight at the end of this week
                dateToTest = ResetTimeValues(dateToTest);
                var daysToEOW = 7 - (int)dateToTest.DayOfWeek;
                dateToTest = dateToTest.AddDays(daysToEOW);

            } // end time-finding while loop

            return dateToTest;
        } // end GetNextMass() 

        /// <summary>
        /// Returns a new DateTime object from the given DateTime with all values Hour and smaller reset to 0.
        /// </summary>
        /// <param name="timeToReset">Initial DateTime object.</param>
        /// <param name="resetHour">Determines if Hour value will be reset.</param>
        /// <param name="resetMinute">Determines if Minute value will be reset.</param>
        /// <returns></returns>

        private DateTime ResetTimeValues(DateTime timeToReset, bool resetHour = true, bool resetMinute = true)
        {
            int hour = 0;
            int minute = 0;
            int second = 0;
            int ms = 0;  // milliseconds
            if (!resetHour)
            {
                hour = timeToReset.Hour;
            }
            if (!resetMinute)
            {
                minute = timeToReset.Minute;
            }
            return new DateTime(timeToReset.Year, timeToReset.Month, timeToReset.Day, hour, minute, second, ms);
        }

        /// <summary>
        /// Returns a new DateTime object, updating the Hour property.
        /// </summary>
        /// <param name="hour">Desired value for Hour property.</param>
        /// <param name="timeToUpdate">Initial DateTime object.</param>
        /// <returns></returns>
        private DateTime UpdateHour(int hour, DateTime timeToUpdate)
        {
            return new DateTime(
                timeToUpdate.Year,
                timeToUpdate.Month,
                timeToUpdate.Day,
                hour,
                timeToUpdate.Minute,
                timeToUpdate.Second
                );
        }

        /// <summary>
        /// Returns a new DateTime object, updating the Minute property.
        /// </summary>
        /// <param name="minute">Desired value for Minute property.</param>
        /// <param name="timeToUpdate">Initial DateTime object.</param>
        /// <returns></returns>
        private DateTime UpdateMinute(int minute, DateTime timeToUpdate)
        {
            return new DateTime(
                timeToUpdate.Year,
                timeToUpdate.Month,
                timeToUpdate.Day,
                timeToUpdate.Hour,
                minute,
                timeToUpdate.Second
                );
        }
    } // end MassTime
}