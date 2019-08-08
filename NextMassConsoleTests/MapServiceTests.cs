using NextMassConsole;
using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextMassConsoleTests
{
    public class MapServiceTests
    {
        MapService _mapService = new MapService();

        [Theory]
        [InlineData("425 W Randolph Chicago", 41.88449, -87.63877)]
        [InlineData("427 S 4th St, Louisville, KY", 38.2518438, -85.757333)] // 4th Street Live
        [InlineData("123 Lake Shore Dr, Michigan City, IN 46360", 41.72817, -86.89383)]
        [InlineData("1310 West Broadway, Louisville, KY 40203-2058", 38.24786, -85.77374)] // St. Augustine
        [InlineData("906 Ardmore Dr, Louisville, KY", 38.2149, -85.73362)] // Clark Park
        [InlineData("1406 E. Washington St., Louisville, KY 40206-1829", 38.25785, -85.72652)] // St. Joseph
        public async void LocateTests(string address, double expectedLat, double expectedLong)
        {
            var actual = await _mapService.Locate(address);
            Assert.Equal(actual.Latitude, expectedLat, 4);
            Assert.Equal(actual.Longitude, expectedLong, 4);
        }

        [Theory]
        [InlineData(38.2518438, -85.757333, 38.24786, -85.77374, 256)] // 4th Street Live to St. Augustine
        [InlineData(38.2149, -85.73362, 38.24786, -85.77374, 723)] // Clark Park to St. Augustine
        [InlineData(38.2518438, -85.757333, 38.25785, -85.72652, 415)] // 4th Street Live to St. Joseph
        [InlineData(38.2149, -85.73362, 38.25785, -85.72652, 758)] // Clark Park to St. Joseph
        public void TravelTimeTests(double startLat, double startLong, double endLat, double endLong, int expectedTravelTime)
        {
            var start = new Location { Latitude = startLat, Longitude = startLong };
            var end = new Location { Latitude = endLat, Longitude = endLong };
            var actual = _mapService.TravelTime(start, end);

            // Assert that actual is with 5% of expected time
            Assert.True(Math.Abs(actual - expectedTravelTime) < expectedTravelTime * .05);
        }
    }
}
