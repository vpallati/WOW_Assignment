using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Website.ViewModels;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Website.Controllers
{
    
    public class ProductController : Controller
    {
        private IProductBusiness _productBuisness;
        private int maxImageSize;

        public ProductController()
        {
            _productBuisness = new ProductBusiness();
            // max image size set to 5 MB
            maxImageSize = 5 * 1024 * 1024;
        }

        [HttpGet]
        [Route("DisplayProducts")]
        public ActionResult DisplayProducts(int? page)
        {
            ViewBag.msg = TempData["success"];
            var model = _productBuisness.GetAllProducts();
            return View(model.Select(a => ProductViewModel.Convert(a)).ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        [Route("DisplayProduct")]
        public ActionResult DisplayProduct(int id)
        {
            var model = _productBuisness.GetProduct(id);
            return View(ProductViewModel.Convert(model));
        }

        [HttpGet]
        [Route("UploadProduct")]
        public ActionResult UploadNewProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("UploadProduct")]
        public ActionResult UploadNewProduct(String Title, String Description, HttpPostedFileBase photo)
        {
            HttpPostedFileBase photo2 = Request.Files["photo"];

            if (photo != null && photo.ContentLength > 0)
            {
                if (photo.ContentLength > maxImageSize)
                {
                    ViewBag.Error = "Image File size should be less than 5MB.";
                    return View();
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ViewBag.Error = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
                    return View();
                }

                // check if file name already exists
                var fileName = Path.GetFileName(photo.FileName);
                var fileInfo = MakeUnique(Path.Combine(Server.MapPath("~/Images"), fileName));
                photo.SaveAs(fileInfo.ToString());

                // create model
                var model = new ProductViewModel()
                {
                    Description = Description,
                    Title = Title,
                    ImageURL = "/Images/" + fileInfo.Name 
                };
                // save model to database
                var dbUpdateStatus = _productBuisness.AddProduct(ProductViewModel.Convert(model));

                if(dbUpdateStatus)
                {
                    // db update successful - redirect to list view 
                    TempData["success"] = "Product Added Successful";
                    return RedirectToAction("DisplayProducts");
                }
                else
                {
                    // delete the image and show error saving to db msg
                }
            }
            ViewBag.Error = "Image Required.";
            return View();
            
        }

        // check if image file name already exists and makes the file name unique
        private FileInfo MakeUnique(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!System.IO.File.Exists(path))
                    return new FileInfo(path);

                path = Path.Combine(dir, fileName + " " + i + fileExt);
            }
        }
    }
}