using System.Collections.Generic;

namespace NextMassConsole.Model
{
    public interface IChurch
    {
        ILocation Coordinates { get; set; }
        ICollection<IMassTime> MassTimes { get; set; }
    }
}