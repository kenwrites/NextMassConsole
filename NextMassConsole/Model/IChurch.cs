using System.Collections.Generic;

namespace NextMassConsole.Model
{
    public interface IChurch
    {
        string Name { get; set; }
        ILocation Coordinates { get; set; }
        ICollection<IMassTime> MassTimes { get; set; }
    }
}