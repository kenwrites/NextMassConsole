using System;

namespace NextMassConsole.Model
{
    public interface IMassTime
    {
        Church Church { get; set; }
        int ChurchId { get; set; }
        DayOfWeek Day { get; set; }
        int Hour { get; set; }
        int Minute { get; set; }
    }
}