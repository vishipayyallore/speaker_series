using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Entities;
using UserService.Persistence;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPreferencesController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public UserPreferencesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/UserPreferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPreference>>> Get()
        {
            var users = await _appDbContext.UserPreferences.ToListAsync();

            return Ok(users);
        }

        // POST: api/UserPreferences
        [HttpPost]
        public async Task<ActionResult<UserPreference>> Post([FromBody] UserPreference userPreference)
        {
            _appDbContext.UserPreferences.Add(userPreference);
            await _appDbContext.SaveChangesAsync();

            return Created(string.Empty, userPreference);
        }

    }
}
