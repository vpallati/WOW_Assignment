using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Website.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace Website.Controllers
{
    
    public class ProductController : Controller
    {
        private IProductBusiness _productBuisness;

        public ProductController()
        {
            _productBuisness = new ProductBusiness();
        }

        [Route("DisplayProducts")]
        public ActionResult DisplayProducts(int? page)
        {
            var model = _productBuisness.GetAllProducts();
            return View(model.Select(a => ProductViewModel.Convert(a)).ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        [Route("UploadProduct")]
        public ActionResult UploadNewProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("UploadProduct")]
        public bool UploadProduct(ProductViewModel model)
        {
            return (_productBuisness.AddProduct(ProductViewModel.Convert(model)));
        }
    }
}