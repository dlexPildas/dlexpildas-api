using Microsoft.AspNetCore.Mvc;

namespace DlexPildas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
       
        /// <summary>
        /// Method to return all articles registered
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            return Ok();
        }
    }
}