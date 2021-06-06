using System;
using ApiMongo.Data.Collections;
using ApiMongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedsCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedsCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        //Register a new person
        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.DateBirth, dto.Genre, dto.Latitude, dto.Longitude);
            _infectedsCollection.InsertOne(infected);
            return StatusCode(201, "Infected added succesfully");
        }

        //Get a register by Birthday row
        [HttpGet]
        public ActionResult GetInfecteds()
        {
            var infecteds = _infectedsCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infecteds);
        }

        //Updates a specific row
        [HttpPatch]
        public ActionResult UpdateOneInfected([FromBody] InfectedDto dto)
        {
            _infectedsCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.DateBirth == dto.DateBirth), Builders<Infected>.Update.Set("genre", dto.Genre));

            return Ok("Genre Patched");
        }


        //Deletes the register of a person by it's Birthday date
        [HttpDelete("{dataNasc}")]
        public ActionResult DeleteInfected(DateTime dateBirth)
        {
            _infectedsCollection.DeleteOne(Builders<Infected>.Filter.Where(_ => _.DateBirth == dateBirth));

            return Ok("Deleted Succesfully");
        }
    }

}