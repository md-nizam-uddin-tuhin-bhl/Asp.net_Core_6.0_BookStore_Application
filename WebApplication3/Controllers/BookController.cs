using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookservice;
        private readonly IAuthorServicecs _autorservice;
        private readonly IGenreService _genreservice;
        private readonly IPublisherService _publisherservice;
        public BookController(IBookService service,IPublisherService publisherService, IGenreService genreService, IAuthorServicecs authorServicecs)
        {
            _bookservice = service;
            _autorservice = authorServicecs;
            _genreservice = genreService;
            _publisherservice = publisherService;

         
        }

        public IActionResult Add()
            
        {
            var model = new Book();
            model.AuthorList = _autorservice.GetAll().Select(a=> new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString()}).ToList();
            model.PublisherList = _publisherservice.GetAll().Select(a=> new SelectListItem { Text = a.PubliserName, Value = a.Id.ToString()}).ToList();
            model.GenreList = _genreservice.GetAll().Select(a=> new SelectListItem { Text = a.Name, Value = a.Id.ToString()}).ToList();
     
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)

        {
            model.AuthorList = _autorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(),Selected =a.Id==model.AuthorId }).ToList();
            model.PublisherList = _publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PubliserName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookservice.Add(model);
            if (result)
            {
                TempData["msg"] = "Add Successfully";
                return RedirectToAction("Add");
            }
            TempData["msg"] = "error has been occured on serverside";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var model= _bookservice.FindByID(id);
            model.AuthorList = _autorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PubliserName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)

        {
            model.AuthorList = _autorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PubliserName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookservice.Update(model);
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

            var result = _bookservice.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = _bookservice.GetAll();
            return View(data);
        }
    }
}
