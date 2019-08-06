using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextMassConsole.Model
{
    public class ChurchService // Get it?
    {
        private NextMassContext _db = new NextMassContext();
        public void AddChurch(IChurch church)
        {
            _db.Churches.Add(new Church(church));
            _db.SaveChanges();
        }
        // TODO:  add options to update only MassTimes, Name, or Coordinates
        public void UpdateChurch(int churchId, IChurch updatedChurch)
        {
            Church churchToUpdate = _db.Churches.Find(churchId);
            churchToUpdate = new Church(updatedChurch);
        }
        public void DeleteChurch(Church church)
        {
            _db.Churches.Remove(church);
            _db.SaveChanges();
        }
        public void DeleteChurch(int churchId)
        {
            _db.Churches.Remove(_db.Churches.Find(churchId));
            SaveChanges();
        }
        // TODO:  implement regex or string.contains.
        public IChurch GetChurch(string name)
        {
            return _db.Churches.First
            (
                c => c.Name.ToLower()
                .Contains(name.ToLower())
            );
        }
        public IChurch GetChurch(int Id)
        {
            return _db.Churches.First(c => c.Id == Id);
        }
        public ICollection<Church> GetNearbyChurches(ILocation location, int distanceInMiles = 10)
        {
            throw new NotImplementedException();            
        }
        public void RemoveAllChurchesForTesting()
        {
            _db.Churches.RemoveRange(
                _db.Churches.ToArray());
            _db.SaveChanges();
        }
        public ICollection<Church> ReturnAllChurchesForTesting()
        {
            return _db.Churches.ToList();
        }
        public bool AnyChurches()
        {
            return _db.Churches.Any();
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
