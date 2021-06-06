using System;

namespace ApiMongo.Models
{
    public class InfectedDto
    {

        public DateTime DateBirth { get; set; }
        public string Genre { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}