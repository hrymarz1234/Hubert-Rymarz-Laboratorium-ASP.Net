
using Laboratorium_2.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_1.Controlers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult About(string author, int? id)
        {

            ViewBag.Author = author + " " + id;

            return View();
        }

        public IActionResult Calculator(string op, double x, double y)
        {

            double result = 0;
            if (op == "sub")
            {
                result = x - y;

            }
            else if (op == "add")
            {
                result = x + y;

            }
            else if (op == "div")
            {
                result = x / y;

            }
            else if (op == "mul")
            {
                result = x * y;

            }





            ViewBag.Result = result;
            return View();
        }

        public IActionResult Calc([FromQuery(Name = "operator")] Operators? op, double? x, double? y)
        {
            if (op == null || x == null || y == null)
            {
                return View("Error");
            }


            double? result = 0;
            switch (op)
            {
                case Operators.SUB:
                    result = x - y;
                    break;
                case Operators.ADD:
                    result = x + y;
                    break;
                case Operators.DIV:
                    result = x / y;
                    break;
                case Operators.MUL:
                    result = x * y;
                    break;
            }
            ViewBag.Result = result;
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}