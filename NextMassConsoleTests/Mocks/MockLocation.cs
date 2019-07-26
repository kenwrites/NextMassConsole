using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsoleTests.Mocks
{
    class MockLocation : ILocation
    {
        public double Latitude { get ; set; }
        public double Longitude { get; set; }
    }
}
