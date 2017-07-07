using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            DataAccessLayer.DataAccess.IProductRepository a = new DataAccessLayer.DataAccess.ProductRepository();
            //a.AddProduct(new DataAccessLayer.Models.ProductModel() {
            //    ProductID = 3,
            //    Description ="",
            //    ImageURL="",
            //    Title =""});
            //a.AddProduct(new DataAccessLayer.Models.ProductModel()
            //{
            //    Description = "",
            //    ImageURL = "",
            //    Title = ""
            //});
            //a.AddProduct(new DataAccessLayer.Models.ProductModel()
            //{
            //    Description = "",
            //    ImageURL = "",
            //    Title = ""
            //});
            //a.AddProduct(new DataAccessLayer.Models.ProductModel()
            //{
            //    Description = "",
            //    ImageURL = "",
            //    Title = ""
            //});
            ViewBag.Message = a.GetAllProducts().Count;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}