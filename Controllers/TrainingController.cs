using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using apiradhiforstage; // Assurez-vous que ce namespace contient le modèle Training

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly IMongoCollection<Training> _trainingCollection;

        public TrainingController(IConfiguration configuration, IMongoClient mongoClient)
        {
            var databaseName = "api"; // Nom de la base de données MongoDB
            _trainingCollection = mongoClient.GetDatabase(databaseName).GetCollection<Training>("api1"); // Collection renommée en 'Training'
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trainingRecords = _trainingCollection.Find(t => true).ToList(); // Récupérer tous les enregistrements de formation de la collection

            return Ok(trainingRecords);
        }

        // Ajouter d'autres méthodes HTTP (POST, PUT, DELETE) selon les besoins
    }
}
