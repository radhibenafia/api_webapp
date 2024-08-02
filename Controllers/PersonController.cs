using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiradhiforstage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly List<Person> People = new List<Person>
        {
            new Person { Nom = "radhi", Prenom = "benafia", NomEntreprise = "mobelite", Date = DateOnly.FromDateTime(DateTime.Now) },
            new Person { Nom = "rayen", Prenom = "benafia", NomEntreprise = "7atchay", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)) },
            new Person { Nom = "Durand", Prenom = "Paul", NomEntreprise = "Websolutions", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)) }
        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPeople")]
        public IEnumerable<Person> Get()
        {
            return People;
        }

        [HttpGet("description/{lang}", Name = "Description")]
        public string Description(string lang)
        {
            switch (lang.ToLower())
            {
                case "en":
                    return "This application is a healthcare system designed to provide comprehensive health monitoring and management.";
                case "fr":
                    return "Cette application est un système de soins de santé conçu pour fournir une surveillance et une gestion complètes de la santé.";
                case "es":
                    return "Esta aplicación es un sistema de atención médica diseñado para proporcionar un monitoreo y gestión de la salud completos.";
                default:
                    return "Language not supported. Please use 'en' for English, 'fr' for French, or 'es' for Spanish.";
            }
        }
        [HttpGet("description/client", Name = "ClientDescription")]
        public IActionResult ClientDescription()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Nom = "radhi", Email = "radhi@gmail.com", Telephone = "29644585" },
                new Client { Id = 2, Nom = "rayen", Email = "rayen@gmail.com", Telephone = "29644585" }
            };

            var clientInfo = new
            {
                NumberOfClients = clients.Count,
                Clients = clients.Select(c => new { c.Id, c.Nom, c.Email, c.Telephone }).ToList()
            };

            return Ok(clientInfo);
        }


    }
        public class Client
    {
            public int Id { get; set; }
            public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

    }
}
