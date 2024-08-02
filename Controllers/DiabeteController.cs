using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using apiradhiforstage; // Assurez-vous que ce namespace contient le modèle Diabete

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiabeteController : ControllerBase
    {
        private readonly IMongoCollection<Diabete> _diabeteCollection;

        public DiabeteController(IConfiguration configuration, IMongoClient mongoClient)
        {
            var databaseName = "api"; // Nom de la base de données MongoDB
            _diabeteCollection = mongoClient.GetDatabase(databaseName).GetCollection<Diabete>("api3");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var diabeteRecords = _diabeteCollection.Find(d => true).ToList(); // Récupérer tous les enregistrements de diabète de la collection

            return Ok(diabeteRecords);
        }

        // Ajouter d'autres méthodes HTTP (POST, PUT, DELETE) selon les besoins
    }
}
