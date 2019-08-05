using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsoleTests.Mocks
{
    class MockMassTime : IMassTime
    {
        public IChurch Church { get; set; }
        public int ChurchId { get; set; }
        public DayOfWeek Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
