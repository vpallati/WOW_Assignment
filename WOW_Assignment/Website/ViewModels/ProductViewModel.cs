using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public static ProductModel Convert(ProductViewModel entity)
        {
            return new ProductModel()
            {
                ProductID = entity.ProductID,
                Title = entity.Title,
                Description = entity.Description,
                ImageURL = entity.ImageURL
            };
        }

        public static ProductViewModel Convert(ProductModel model)
        {
            return new ProductViewModel()
            {
                ProductID = model.ProductID,
                Title = model.Title,
                Description = model.Description,
                ImageURL = model.ImageURL
            };
        }
    }
}