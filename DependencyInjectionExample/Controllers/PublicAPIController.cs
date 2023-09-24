using DependencyInjectionExample.Models.PublicAPIModels;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]/users")]
    public class PublicAPIController : ControllerBase
    {
        /*
         * Производим внедрение сервиса в контроллер, путем определения интерфейса данного сервиса в конструкторе.
         */
        private readonly IPublicAPIUsersService _userSerice;
        private List<PublicAPIUser> users;

        public PublicAPIController(IPublicAPIUsersService userService)
        {
            _userSerice = userService;
            users = _userSerice.GetUsers().Result.ToList();
        }

        [HttpGet]
        public IEnumerable<PublicAPIUser> Get() => users;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PublicAPIUser user = users.SingleOrDefault(p => p.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
