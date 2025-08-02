using asp.netCore_project.Data;
using asp.netCore_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace asp.netCore_project.Controllers
{
    [Authorize(Roles =ClsRolse.roleAdmin)]
    public class itemsController : Controller
    {
        public itemsController(AppDbContext context , IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }
        private readonly IHostingEnvironment _hosting;
        private readonly AppDbContext _context;
        public IActionResult Index()
        {
            IEnumerable<items> list =_context.items.Include(e=>e.Category).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult add()
        {
            createSelectList();
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(items obj)
        {
            if (obj.Price < 0)
            {
                ModelState.AddModelError("Price"," السعر غير صالح");
            }
            if (obj.CategoryId == 1)
            {
                ModelState.AddModelError("CategoryId", "  لم تختار تصنيف");

            }
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (obj.clintfile != null)
                {
                    string myUpload = Path.Combine(_hosting.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.clintfile.FileName);
                    string fullpath = Path.Combine(myUpload, fileName);
                    obj.clintfile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    obj.imagePath = fileName;
                }
                _context.items.Add(obj);
                _context.SaveChanges();
                TempData["SuccessData"] = "تمت الاضافة بنجاح";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public void createSelectList(int selectId =1)
        {
            //    List<Category> categories = new List<Category>()
            //    {
            //        new Category(){ Id =0 , Name = "select Category"},
            //        new Category(){ Id =1 , Name = "computers"},
            //        new Category(){ Id =2 , Name = "MObiles"},
            //        new Category(){ Id =3 , Name = "Electric Machines"},
            //        new Category(){ Id =4 , Name = "Others"}
            //    };


            List<Category> categories= _context.categories.ToList();

            SelectList listItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listItems;
        }
        [HttpGet]
        public IActionResult Edite(int? Id)
        {
            if (Id == null || Id ==0)
            {
                return NotFound();
            }
           
            var item = _context.items.FirstOrDefault(i=> i.Id == Id);
            createSelectList(item.CategoryId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(items obj)
        {
            if (obj.CategoryId == 1)
            {
                ModelState.AddModelError("CategoryId", "  لم تختار تصنيف");

            }
            
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (obj.clintfile != null)
                {
                    string myUpload = Path.Combine(_hosting.WebRootPath, "images");
                    fileName = obj.clintfile.FileName;
                    string fullpath = Path.Combine(myUpload, fileName);
                    obj.clintfile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    obj.imagePath = fileName;
                }
                _context.items.Update(obj);
                _context.SaveChanges();
                TempData["SuccessData"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            createSelectList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delate(int? Id)
        {
            if (Id == null || Id ==0)
            {
                return NotFound();
            }
            
            var item = _context.items.FirstOrDefault(i=> i.Id == Id);
            createSelectList(item.CategoryId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delate(items obj)
        {
           
            if (ModelState.IsValid)
            {
                _context.items.Remove(obj);
                _context.SaveChanges();
                TempData["SuccessDat"] = "تم الحذف بنجاح";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
