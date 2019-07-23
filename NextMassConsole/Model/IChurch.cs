using System.Collections.Generic;

namespace NextMassConsole.Model
{
    public interface IChurch
    {
        Location Location { get; set; }
        List<MassTime> MassTimes { get; set; }
    }
}