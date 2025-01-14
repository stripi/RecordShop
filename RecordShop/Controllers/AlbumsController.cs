using Microsoft.AspNetCore.Mvc;

namespace RecordShop.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {

            RecordShopDbContext rs = new RecordShopDbContext();

            return Ok(rs.Albums.ToList());
        }
    }
}
