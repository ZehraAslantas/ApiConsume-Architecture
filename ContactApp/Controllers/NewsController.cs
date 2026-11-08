using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [Route("news")] // url de /news yazınca buraya gelsin
    public class NewsController : Controller
    {
        private readonly INewsService _newsServices;

        public NewsController(INewsService newsServices)
        {
            _newsServices = newsServices;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken) //Task ile asenkron yapıyoruz
        {
            var articles = await _newsServices.GetAllAsync(cancellationToken);
            return View(articles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken) 
        {
            var article = await _newsServices.GetByIdAsync(id,cancellationToken);
            if(article is null)
            { 
                return NotFound(); // 404
            }
            return View(article);
        }
    }
}
