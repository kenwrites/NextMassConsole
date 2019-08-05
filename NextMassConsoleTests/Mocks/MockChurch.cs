using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsoleTests.Mocks
{
    class MockChurch : IChurch
    {
        // TODO:  update DbContext to handle interface
        public Location Coordinates { get; set; }
        // TODO:  update DbContext to handle interface
        public List<MassTime> MassTimes { get; set; }
    }
}
