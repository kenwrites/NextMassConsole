using NextMassConsole.Model;
using NextMassConsoleTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextMassConsoleTests
{
   
    public class MassTimeTests
    {
        [Theory]
        //  Happy Path:
        [InlineData("Sunday", 9, 30)]
        [InlineData("Saturday", 17, 30)]
        // Edge Cases:
        [InlineData("Sunday", 23, 1)]
        [InlineData("Sunday", 1, 59)]
        [InlineData("Sunday", 0, 1)]
        [InlineData("Sunday", 1, 0)]
        public void ConstructorTests_ValidInput(string dayInput, int hourInput, int minuteInput)
        {                    
            DayOfWeek dayAsDayOfWeek = Enum.Parse<DayOfWeek>(dayInput);

            var mt = new MassTime(day: dayAsDayOfWeek, hour: hourInput, minute: minuteInput, new MockChurch());

            Assert.True
                (
                    mt.Hour == hourInput &&
                    mt.Minute == minuteInput &&
                    mt.Day == dayAsDayOfWeek
                );
        }

        [Theory]
        [InlineData("Sunday", -1, 1)]
        [InlineData("Sunday", 24, 1)]
        [InlineData("Sunday", 1, -1)]
        [InlineData("Sunday", 1, 60)]
        public void ConstructorTests_InvalidInput(string day, int hour, int minute)
        {
            Assert.Throws<InvalidTimeException>
            (
                () => new MassTime
                (
                    day: Enum.Parse<DayOfWeek>(day), 
                    hour: hour, 
                    minute: minute, 
                    new MockChurch()
                )
            );
        }

        [Theory]
        [InlineData("Sunday", 8, 30, 2019, 7, 26, 12, 47, 0, 2019, 7, 28, 8, 30, 0)] // Sun @ 9:30A
        [InlineData("Saturday", 16, 30, 2019, 7, 26, 12, 47, 0, 2019, 7, 27, 16, 30, 0)] // Sat @ 5:30P 
        [InlineData("Sunday", 10, 0, 2019, 7, 26, 12, 47, 0, 2019, 7, 28, 10, 0, 0)] // Sun @ 11:00A
        [InlineData("Saturday", 17, 15, 2019, 7, 26, 12, 47, 0, 2019, 7, 27, 17, 15, 0)] // Sat @ 7:15P
        [InlineData("Monday", 5, 0, 2019, 7, 26, 12, 47, 0, 2019, 7, 29, 5, 0, 0)] // Mon @ 6:00A
        [InlineData("Sunday", 11, 0, 2019, 7, 26, 12, 47, 0, 2019, 7, 28, 11, 0, 0)] // Sunday @ 12:00P
        // Test crossing month boundary 
        [InlineData("Sunday", 11, 0, 2019, 7, 31, 12, 47, 0, 2019, 8, 4, 11, 0, 0)] // Sunday @ 12:00P
        // Test crossing year boundary 
        [InlineData("Sunday", 11, 0, 2019, 12, 31, 12, 47, 0, 2020, 1, 5, 11, 0, 0)] // Sunday @ 12:00P
        public void GetNextMassTests(string day, int hour, int minute, int nowYear, int nowMonth, int nowDay, int nowHour, int nowMin, int nowSec, int correctYear, int correctMonth, int correctDay, int correctHour, int correctMin, int correctSec)
        {
            DateTime now = new DateTime(nowYear, nowMonth, nowDay, nowHour, nowMin, nowSec);
            MassTime mt = new MassTime(
                day: Enum.Parse<DayOfWeek>(day), 
                hour: hour, 
                minute: minute, 
                new MockChurch());
            DateTime expected = new DateTime(correctYear, correctMonth, correctDay, correctHour, correctMin, correctSec);

            Assert.Equal(expected, mt.GetNextMass(now));
        }

    }
}
