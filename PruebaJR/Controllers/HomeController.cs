using Microsoft.AspNetCore.Mvc;
using PruebaJR.Models;
using PruebaJR.Repositories;
using System.Diagnostics;

namespace PruebaJR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IAutorRepository _autorRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, IAutorRepository autorRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _autorRepository = autorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();

            return View(books);
        }

        public async Task<IActionResult> CreateBook()
        {
            ViewBag.Autors = await _autorRepository.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookViewModelCreating model)
        {
            if(ModelState.IsValid)
            {
                await _bookRepository.Create(model);

                return RedirectToAction("Index");
            }

            ViewBag.Autors = await _autorRepository.GetAll();
            return View();
        }

        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AutorViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _autorRepository.Create(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
