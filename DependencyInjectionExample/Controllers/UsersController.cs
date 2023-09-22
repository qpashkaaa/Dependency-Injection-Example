using DependencyInjectionExample.Models;
using DependencyInjectionExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userSerice;
        private List<User> users;

        public UsersController(IUsersService usersService)
        {
            _userSerice = usersService;
            users = _userSerice.GetUser().Result.ToList();
        }

        [HttpGet]
        public IEnumerable<User> Get() => users;


        /*
         * Users are taken randomly at each request, so it is almost impossible to get them by id. But if the data were static, 
         * it would be possible to get the user at /api/publicAPI/users/{id}
         */
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = users.SingleOrDefault(p => p.id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
