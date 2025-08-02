using asp.netCore_project.Models;
using asp.netCore_project.Repository;
using asp.netCore_project.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace asp.netCore_project.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
       
        //private IRepositry<Category> _cRepository;
        private readonly IUntiOfWork unti;
        public CategoryController(IUntiOfWork _myUnti)
        {
           unti = _myUnti; 
        }
        //public IActionResult Index()
        //{
        //    return View(_cRepository.FindAll());
        //}
        public async Task<IActionResult> Index()
        {
            var onecat = unti.Categories.SelectOne(c => c.Name == "MObiles");
            var allcats = await unti.Categories.FindAllAsync("items");
            
            return View(allcats);
        }
        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                unti.Categories.AddOne(category);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("error", "Please enter valid data");
                return View(category);
            }

        }
        // GET: Category/Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var category = unti.Categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                // Update logic here
                unti.Categories.UpdateOne(category);
                TempData["SuccessDat"] = "تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("error", "Please enter valid data");
                return View(category);
            }


        }
        // GET: Category/Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var category = unti.Categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: Category/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                // Delete logic here
                unti.Categories.DeleteOne(category);
                TempData["message"] = "Category deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("error", "Please enter valid data");
                return View(category);
            }


        }

    }
}
