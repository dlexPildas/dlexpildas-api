using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DlexPildas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllReminders() 
        {
            return Ok(new {  Id = 1, Name = "Daniel"  });    
        }


        [HttpGet("{id}")]
        public IActionResult GetReminderById()
        {
            return Ok("");
        }
        
    }
}