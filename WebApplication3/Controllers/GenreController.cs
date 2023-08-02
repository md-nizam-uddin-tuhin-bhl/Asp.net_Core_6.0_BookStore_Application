using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _service;
        public GenreController(IGenreService service)
        {
            _service = service;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Add(model);
            if(result)
            {
                TempData["msg"] = "Add Successfully";   
                return RedirectToAction("Add");
            }
            TempData["msg"] = "error has been occured on serverside";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var record = _service.FindByID(id);

            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Update(model);
            if (result)
            {
                TempData["msg"] = "Update Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "error has been occured on serverside";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
           
            var result = _service.Delete(id);
            return RedirectToAction("GetAll");
        } 

        public IActionResult GetAll()
        {
           
            var data = _service.GetAll();
            return View(data);
        }

    }
}
