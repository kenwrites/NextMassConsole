using System;
using System.Net.Http;

namespace NextMassConsole
{
    class Program
    {
        public static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            MapService mapService = new MapService();
            var location = mapService.Locate("906 Ardmore Dr., Louisville, KY");

            Console.ReadKey(true);         
            

        }
    }
}
