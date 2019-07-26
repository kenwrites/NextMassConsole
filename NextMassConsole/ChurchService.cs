using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsole.Model
{
    public class ChurchService // Get it?
    {
        private NextMassContext _db = new NextMassContext();
        public void AddChurch(IChurch church)
        {
            //_db.Churches.Add(new Church(church));
        }
        public void UpdateChurch(int churchId, IChurch updatedChurch)
        {
            //Church churchToUpdate = _db.Churches.Find(churchId);
            //churchToUpdate = new Church(updatedChurch);
        }
        public void DeleteChurch(Church church)
        {
            _db.Churches.Remove(church);
        }
        public void DeleteChurch(int churchId)
        {
        }
        public IChurch GetChurch(string name)
        {
            return new Church();
        }
        public IChurch GetChurch(int Id)
        {
            return new Church();
        }
        public ICollection<Church> GetNearbyChurches(ILocation location, int distanceInMiles = 10)
        {
            return new List<Church>();
        }
        public ICollection<Church> ReturnAllChurchesForTesting()
        {
            //_db.Churches.
            return new List<Church>();
        }
    }
}
