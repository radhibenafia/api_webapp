using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using apiradhiforstage;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {
        private readonly IMongoCollection<Employe> _employeCollection;

        public EmployeController(IConfiguration configuration, IMongoClient mongoClient)
        {
            var databaseName = "api"; // Nom de la base de données MongoDB
            _employeCollection = mongoClient.GetDatabase(databaseName).GetCollection<Employe>("Person");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employes = _employeCollection.Find(e => true).ToList(); // Récupérer tous les employés de la collection

            return Ok(employes);
        }
    }
}
