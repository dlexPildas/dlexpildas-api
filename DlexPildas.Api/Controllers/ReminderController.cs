using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DlexPildas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        /// <summary>
        /// Method to return all reminders registereds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllReminders() 
        {
            return Ok(new {  Id = 1, Name = "Daniel"  });    
        }

        /// <summary>
        /// Method to return a specific reminder by id
        /// </summary>
        /// <param name="id">Id of a reminder</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetReminderById(int id)
        {
            return Ok("");
        }
        
    }
}