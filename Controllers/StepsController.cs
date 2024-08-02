using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using apiradhiforstage;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StepsController : ControllerBase
    {
        private readonly IMongoCollection<Steps> _stepsCollection;

        public StepsController(IConfiguration configuration, IMongoClient mongoClient)
        {
            var databaseName = "api"; // Nom de la base de données MongoDB
            _stepsCollection = mongoClient.GetDatabase(databaseName).GetCollection<Steps>("api2");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employes = _stepsCollection.Find(e => true).ToList(); // Récupérer tous les employés de la collection

            return Ok(employes);
        }
    }
}
