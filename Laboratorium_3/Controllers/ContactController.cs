using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Laboratorium_3.Models;


namespace Laboratorium_3.Controllers
{


    public class ContactController : Controller
    {


        private readonly IContactService _contactService;

        private readonly IDateTimeProvider _dateTimeProvider;

        public ContactController(IDateTimeProvider timeProvider, IContactService contactService)
        {
            _dateTimeProvider = timeProvider;
            _contactService = contactService;
        }

        public IActionResult Index()
        {

            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.DeleteById(model.Id);
            return RedirectToAction("Index");
        }
        
    }

}