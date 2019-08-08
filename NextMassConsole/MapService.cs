using NextMassConsole.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace NextMassConsole
{
    public class MapService
    {
        private static readonly HttpClient _http = new HttpClient();
        private static readonly string _apiEndpoint = "https://geocoder.api.here.com/6.2/geocode.json?";
        private string _baseURL;
        private static JsonTools _jsonTools = new JsonTools();
        private ConfigFile _configFile;
        private JsonSerializer _serializer = new JsonSerializer();

        private static string AddAPICredentials(string baseUrl, string appId, string appCode)
        {
            return $"{baseUrl}app_id={appId}&app_code={appCode}";
        }

        public MapService()
        {
            _configFile = _jsonTools.ReadFile<ConfigFile>("config.json");
            _baseURL = AddAPICredentials(_apiEndpoint, _configFile.HereAppId, _configFile.HereAppCode);
        }

        /// <summary>
        /// Returns latitude and longitude for a given address as an ILocation object.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<ILocation> Locate(string address)
        {
            Uri requestUri = new Uri($"{_baseURL}&searchtext={address}");
            string httpResponse = "";

            try
            {
                httpResponse = await _http.GetStringAsync(requestUri);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var response = _jsonTools.ReadString<GeoCodeResponse>(httpResponse, Encoding.Default);           

            var navPosition = response.Response.View
                // View[] should only have one View, so take first View
                .First(v => v is View)
                .Result
                // Get result with highest Relevance
                .OrderByDescending(r => r.Relevance).First()
                .Location.NavigationPosition.First();

            return new Location { Latitude = navPosition.Latitude, Longitude = navPosition.Longitude };
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
