using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsole.Model
{

    // This is an entity which models the many-to-many relationship between Churches and Users.
    public class ChurchUser
    {
        public int ChurchId { get; set; }
        public Church Church { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
