using Microsoft.AspNetCore.Mvc;
using WebApplication2.BL.Interface;
using WebApplication2.DAL.Entities;
using WebApplication2.Models;
using System.Diagnostics;

namespace WebApplication2.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductRep _productRep;

        public ProductController1(IProductRep productRep)
        {
            _productRep = productRep;
        }

        public IActionResult Index()
        {
            var data = _productRep.Get();
            return View(data);
        }
        
        
        public IActionResult Create()
        {
          return View();    
        }

        [HttpPost]
        public IActionResult Create(ProductVM Pdt)
        {
            try
            {
                if (ModelState.IsValid) {

                    _productRep.Add(Pdt); // الإضافة باستخدام الـ Repository
                    return RedirectToAction("Index"); // توجيه إلى قائمة المنتجات
                }

                return View(Pdt);
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); // عرض الخطأ أثناء التطوير
                return View(Pdt); // إعادة عرض النموذج مع الأخطاء
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _productRep.GetById(id);
            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(ProductVM Pdt)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _productRep.Edit(Pdt); // الإضافة باستخدام الـ Repository
                    return RedirectToAction("Index"); // توجيه إلى قائمة المنتجات
                }

                return View(Pdt);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); // عرض الخطأ أثناء التطوير
                return View(Pdt); // إعادة عرض النموذج مع الأخطاء
            }
        }


        public IActionResult Delete(int id)
        {
            var data = _productRep.GetById(id);
            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
               

                    _productRep.Delete(id); // الإضافة باستخدام الـ Repository
                    return RedirectToAction("Index"); // توجيه إلى قائمة المنتجات
               

              

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); // عرض الخطأ أثناء التطوير
                return View(); // إعادة عرض النموذج مع الأخطاء
            }
        }



    }
}
