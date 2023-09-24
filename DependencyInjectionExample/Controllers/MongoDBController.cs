﻿using DependencyInjectionExample.Models.MongoDBModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]/users")]
    public class MongoDBController : ControllerBase
    {
        /*
         * Производим внедрение сервиса в контроллер, путем определения интерфейса данного сервиса в конструкторе.
         */
        private readonly IMongoDBUsersService _userSerice;
        private List<MongoDBUser> users;
        public MongoDBController(IMongoDBUsersService userService)
        {
            _userSerice = userService;
            users = _userSerice.GetUsers().Result.ToList();
        }

        [HttpGet]
        public IEnumerable<MongoDBUser> Get() => users;


        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            MongoDBUser user = users.SingleOrDefault(p => p.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
