using System;

namespace NextMassConsole.Model
{
    public interface IMassTime
    {
        IChurch Church { get; set; }
        int ChurchId { get; set; }
        DayOfWeek Day { get; set; }
        int Hour { get; set; }
        int Minute { get; set; }
    }
}