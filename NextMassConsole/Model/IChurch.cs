using System.Collections.Generic;

namespace NextMassConsole.Model
{
    public interface IChurch
    {
        Location Coordinates { get; set; }
        List<MassTime> MassTimes { get; set; }
    }
}