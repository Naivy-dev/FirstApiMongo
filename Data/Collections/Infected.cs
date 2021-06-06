using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiMongo.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime dateBirth, string genre, double latitude, double longitude)
        {
            this.DateBirth = dateBirth;
            this.Genre = genre;
            this.Localization = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public DateTime DateBirth { get; set; }
        public string Genre { get; set; }
        public GeoJson2DGeographicCoordinates Localization { get; set; }
    }
}