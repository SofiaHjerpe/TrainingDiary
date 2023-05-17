using Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainingDiary.Models;

namespace TrainingDiary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var db = new SqlDatabase();
            var training  = db.GetTrainings();
            return View(training);
        }


        public IActionResult Details(int Id)
        {
            var db = new SqlDatabase();
            var training = db.GetTrainingById(Id);

            return View(training);

        }
        public IActionResult Create(int Id)
        {
            var db = new SqlDatabase();
            var training = db.GetTrainingById(Id);

            return View(training);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, string exercise, int sets, int reps, int weights)
        {
            var db = new SqlDatabase();
            db.SaveTraining(id, exercise, sets, reps, weights);
            return Redirect("/Home");
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