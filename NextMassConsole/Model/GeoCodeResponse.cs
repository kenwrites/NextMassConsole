using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsole.Model
{    
    public class GeoCodeResponse
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public Metainfo MetaInfo { get; set; }
        public View[] View { get; set; }
    }

    public class Metainfo
    {
        public DateTime Timestamp { get; set; }
    }

    public class View
    {
        public string _type { get; set; }
        public int ViewId { get; set; }
        public Result[] Result { get; set; }
    }

    public class Result
    {
        public double Relevance { get; set; }
        public string MatchLevel { get; set; }
        public Matchquality MatchQuality { get; set; }
        public string MatchType { get; set; }
        public JsonLocation Location { get; set; }
    }

    public class Matchquality
    {
        public double State { get; set; }
        public double City { get; set; }
        public double[] Street { get; set; }
        public double HouseNumber { get; set; }
        public double PostalCode { get; set; }
    }

    public class JsonLocation
    {
        public string LocationId { get; set; }
        public string LocationType { get; set; }
        public Displayposition DisplayPosition { get; set; }
        public Navigationposition[] NavigationPosition { get; set; }
        public Mapview MapView { get; set; }
        public Address Address { get; set; }
    }

    public class Displayposition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Mapview
    {
        public Topleft TopLeft { get; set; }
        public Bottomright BottomRight { get; set; }
    }

    public class Topleft
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Bottomright
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Address
    {
        public string Label { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public Additionaldata[] AdditionalData { get; set; }
    }

    public class Additionaldata
    {
        public string value { get; set; }
        public string key { get; set; }
    }

    public class Navigationposition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
