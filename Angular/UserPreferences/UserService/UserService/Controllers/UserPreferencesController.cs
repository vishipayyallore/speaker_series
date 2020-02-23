using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPreferencesController : ControllerBase
    {
        // GET: api/UserPreferences
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/UserPreferences
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
    }
}
