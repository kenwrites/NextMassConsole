using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsoleTests.Mocks
{
    class MockChurch : IChurch
    {
        public string Name { get; set; }
        public ILocation Coordinates { get; set; }
        // TODO:  update DbContext to handle interface
        public ICollection<IMassTime> MassTimes { get; set; }
        
    }
}
