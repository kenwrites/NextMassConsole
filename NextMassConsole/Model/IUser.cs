using System.Collections.Generic;

namespace NextMassConsole.Model
{
    public interface IUser
    {
        Location DefaultLocation { get; set; }
        List<ChurchUser> FavoriteChurches { get; set; }
    }
}