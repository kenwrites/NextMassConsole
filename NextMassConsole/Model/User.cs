using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextMassConsole.Model
{
    public class User : IUser
    {
        public int Id { get; set; }
        public Location DefaultLocation { get; set; }
        public List<ChurchUser> FavoriteChurches { get; set; }
    }
}