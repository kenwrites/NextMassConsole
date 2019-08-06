using NextMassConsole.Model;
using NextMassConsoleTests.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace NextMassConsoleTests
{
    public class ChurchServiceTests
    {
        private ChurchService _churchService = new ChurchService();

        [Theory]
        [InlineData(84.22322, 23.22344, "Saturday", 9, 30, "Saturday", 11, 30)]
        [InlineData(24.44932, 25.224343, "Sunday", 7, 00, "Sunday", 9, 00)]
        public void AddChurch_MockChurch_Tests(double lattitude, double longitude, string day1, int hour1, int minute1, string day2, int hour2, int minute2)
        {
            var churchLoc = new MockLocation { Latitude = lattitude, Longitude = longitude };
            var massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day1), Hour = hour1, Minute = minute1 },
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day2), Hour = hour2, Minute = minute2 },
            };
            var expected = new MockChurch { Coordinates = churchLoc, MassTimes = massTimes};
            var actualListBefore = (List<IChurch>)_churchService.ReturnAllChurchesForTesting();

            _churchService.AddChurch(expected);

            var actualListAfter = _churchService.ReturnAllChurchesForTesting();

            Assert.True(
                actualListAfter.Count == actualListBefore.Count + 1 && 
                actualListAfter.Contains(expected));
        }

        [Theory]
        [InlineData(84.22322, 23.22344, "Saturday", 9, 30, "Saturday", 11, 30)]
        [InlineData(24.44932, 25.224343, "Sunday", 7, 00, "Sunday", 9, 00)]
        public void AddChurch_Church_Tests(double lattitude, double longitude, string day1, int hour1, int minute1, string day2, int hour2, int minute2)
        {
            var churchLoc = new MockLocation { Latitude = lattitude, Longitude = longitude };
            var massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day1), Hour = hour1, Minute = minute1 },
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day2), Hour = hour2, Minute = minute2 },
            };
            var expected = new Church { Coordinates = churchLoc, MassTimes = massTimes };
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            _churchService.AddChurch(expected);

            var actualListAfter = _churchService.ReturnAllChurchesForTesting();

            Assert.True(
                actualListAfter.Count == actualListBefore.Count + 1 &&
                actualListAfter.Contains(expected));
        }

        [Theory]
        [InlineData(54.223432, 10.98372)]
        [InlineData(21.362920, 67.443020)]
        public void UpdateChurch_Location_Tests(double lattitude, double longitude)
        {
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            // If no churches in DbSet, add some
            if (actualListBefore.Count == 0)
            {
                AddSomeChurches();
                actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            }

            var churchToUpdate = actualListBefore.Find(c => c is IChurch);
            var updatedLoc = new MockLocation { Latitude = lattitude, Longitude = longitude };
            churchToUpdate.Coordinates = updatedLoc;

            _churchService.UpdateChurch(churchToUpdate.Id, churchToUpdate);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            var actual = actualListAfter.Find(c => c.Id == churchToUpdate.Id);

            Assert.Equal(churchToUpdate.Coordinates, actual.Coordinates);

        }

        [Theory]
        [InlineData("Sunday", 10, 30, "Sunday", 12, 00)]
        [InlineData("Saturday", 5, 30, "Sunday", 8, 00)]
        public void UpdateChurch_MassTimes_Tests(string day1, int hour1, int minute1, string day2, int hour2, int minute2)
        {
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            // If no churches in DbSet, add one
            if (actualListBefore.Count == 0)
            {
                AddSomeChurches();
                actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            }

            var churchToUpdate = actualListBefore.Find(c => c is IChurch);
            var newMassTimes = new List<IMassTime>
            {
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day1), Hour = hour1, Minute = minute1 },
                new MockMassTime { Day = Enum.Parse<DayOfWeek>(day2), Hour = hour2, Minute = minute2 },
            };
            churchToUpdate.MassTimes = newMassTimes;

            _churchService.UpdateChurch(churchToUpdate.Id, churchToUpdate);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            var actual = actualListAfter.Find(c => c.Id == churchToUpdate.Id);

            Assert.Equal(churchToUpdate.MassTimes, actual.MassTimes);

        }

        [Fact]
        public void DeleteChurch_FirstChurch_Test()
        {
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            
            // If no churches in DbSet, add some
            if (actualListBefore.Count == 0)
            {
                AddSomeChurches();
                actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            }

            var churchToDelete = actualListBefore.Find(c => c is IChurch);

            _churchService.DeleteChurch(churchToDelete);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            Assert.True(actualListAfter.Count == actualListBefore.Count - 1 &&
                !actualListAfter.Contains(churchToDelete));

        }

        [Fact]
        public void DeleteChurch_LastChurchWithDuplicates_Test()
        {
            AddSomeChurches();
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            var churchToDelete = actualListBefore.FindLast(c => c is IChurch);

            _churchService.DeleteChurch(churchToDelete);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            Assert.True(actualListAfter.Count == actualListBefore.Count - 1 &&
                !actualListAfter.Contains(churchToDelete));
        }

        [Fact]
        public void DeleteChurch_ChurchInMiddleWithDuplicates_Test()
        {
            AddSomeChurches();
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            var churchToDelete = actualListBefore.Find(c => c.Coordinates.Latitude == 18.34432);

            _churchService.DeleteChurch(churchToDelete);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();

            Assert.True(actualListAfter.Count == actualListBefore.Count - 1 &&
                !actualListAfter.Contains(churchToDelete));
        }        

        [Theory]
        // Happy path
        [InlineData("Test2")]
        // Edge case: delete 1 of 2 duplicate churches
        [InlineData("TestIdenticalChurch")]
        public void DeleteChurch_ChurchId_Test(string churchName)
        {
            AddSomeChurches();
            var actualListBefore = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            var churchToDelete = actualListBefore.Find(c => c.Name == churchName);

            _churchService.DeleteChurch(churchToDelete.Id);

            var actualListAfter = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            Assert.True(actualListAfter.Count == actualListBefore.Count - 1 &&
                !actualListAfter.Contains(churchToDelete));
        }

        [Theory]
        // Happy Path
        [InlineData("Test1")]
        [InlineData("Test2")]
        // Edge Case:  duplicate churches
        [InlineData("TestIdenticalChurch")]
        public void GetChurch_ByName_Tests(string churchName)
        {
            AddSomeChurches();
            var actual = _churchService.GetChurch(churchName);

            Assert.True(actual is IChurch &&
                actual.Name == churchName);
        }

        [Theory]
        // Happy Path
        [InlineData("Test1")]
        [InlineData("Test2")]
        // Edge Case:  duplicate churches
        [InlineData("TestIdenticalChurch")]
        public void GetChurch_ById_Tests(string churchName)
        {
            AddSomeChurches();
            var actualList = (List<Church>)_churchService.ReturnAllChurchesForTesting();
            var expected = actualList.Find(c => c.Name == churchName);

            var actual = (Church)_churchService.GetChurch(expected.Id);

            Assert.True(actual is IChurch &&
                actual.Id == expected.Id &&
                actual.Name == expected.Name);
        }

        private void AddSomeChurches()
        {
            var churchLoc = new MockLocation { Latitude = 21.85843, Longitude = 32.44373 };
            var massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = DayOfWeek.Saturday, Hour = 5, Minute = 30 },
                new MockMassTime { Day = DayOfWeek.Sunday, Hour = 7, Minute = 30 },
            };
            var newChurch = new Church { Coordinates = churchLoc, MassTimes = massTimes, Name = "Test1" };
            _churchService.AddChurch(newChurch);

            churchLoc = new MockLocation { Latitude = 31.33223, Longitude = 62.4432234 };
            massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = DayOfWeek.Saturday, Hour = 19, Minute = 30 },
                new MockMassTime { Day = DayOfWeek.Sunday, Hour = 9, Minute = 00 },
            };
            newChurch = new Church { Coordinates = churchLoc, MassTimes = massTimes, Name = "Test2" };
            _churchService.AddChurch(newChurch);

            // identical church 1
            churchLoc = new MockLocation { Latitude = 18.34432, Longitude = 43.223423 };
            massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = DayOfWeek.Saturday, Hour = 20, Minute = 30 },
                new MockMassTime { Day = DayOfWeek.Sunday, Hour = 11, Minute = 00 },
            };
            newChurch = new Church { Coordinates = churchLoc, MassTimes = massTimes, Name = "TestIdenticalChurch" };
            _churchService.AddChurch(newChurch);

            // identical church 2
            churchLoc = new MockLocation { Latitude = 18.34432, Longitude = 43.223423 };
            massTimes = new List<IMassTime>
            {
                new MockMassTime { Day = DayOfWeek.Saturday, Hour = 20, Minute = 30 },
                new MockMassTime { Day = DayOfWeek.Sunday, Hour = 11, Minute = 00 },
            };
            newChurch = new Church { Coordinates = churchLoc, MassTimes = massTimes, Name = "TestIdenticalChurch" };
            _churchService.AddChurch(newChurch);        
        }

    }
}
