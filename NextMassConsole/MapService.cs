using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsole
{
    public class MapService
    {
        public ILocation Locate(string address)
        {
            return new Location();
        }

        /// <summary>
        /// Returns travel time in seconds between given locations.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Travel time in seconds.</returns>
        public int TravelTime(ILocation start, ILocation end)
        {
            return 0; 
        }

    }
}
