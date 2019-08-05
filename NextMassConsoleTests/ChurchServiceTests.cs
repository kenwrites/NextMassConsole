using NextMassConsole.Model;
using NextMassConsoleTests.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace NextMassConsoleTests
{
    public class ChurchServiceTests
    {
        [Theory]
        [InlineData()]
        public void AddChurchTests(double lattitude, double longitude)
        {
            var churchLoc = new MockLocation { Latitude = lattitude, Longitude = longitude };
            var massTimes = new List<MassTime> { };
            var expected = new MockChurch { Coordinates = churchLoc, MassTimes = massTimes};
        }
        
        
    }
}
