using NextMassConsole.Model;
using NextMassConsoleTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextMassConsoleTests
{
    public class LocationTests
    {
        // Test Constructors

        
        [Fact]
        public void LocationConstructor_ILocation_Test()
        {
            ILocation iLoc = new MockLocation();
            iLoc.Latitude = 89.22232;
            iLoc.Longitude = 22.44322;

            Location newLocation = new Location(iLoc);

            Assert.Equal(
                new { Lat = iLoc.Latitude, Long = iLoc.Longitude },
                new { Lat = newLocation.Latitude, Long = newLocation.Longitude }
            );
        }

        [Theory]
        [InlineData("23.23232", "41.223434")]
        [InlineData("0.1","0.1")]
        [InlineData("-23.34432","-44.44342")]
        [InlineData("-90", "0")]
        [InlineData("90", "0")]
        [InlineData("0", "-180")]
        [InlineData("0", "180")]
        public void LocationConstructor_GoodString_Test(string lat, string lon)
        {
            var newLoc = new Location(lat, lon);

            double latAsDouble = double.Parse(lat);
            double longAsDouble = double.Parse(lon);

            Assert.Equal(
                new { Lat = newLoc.Latitude, Long = newLoc.Longitude },
                new { Lat = latAsDouble, Long = longAsDouble }
            );
        }

        [Theory]
        [InlineData("abkd", "02.aa1")]
        [InlineData("-91", "0")]
        [InlineData("91","0")]
        [InlineData("0", "-181")]
        [InlineData("0","181")]
        public void LocationConstructor_BadString_Test(string lat, string lon)
        {
            Assert.Throws<InvalidLatOrLongException>(
                () => new Location(lat, lon)
            );
        }
       
    }
}
