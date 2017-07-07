using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public static ProductModel Convert(Product entity)
        {
            return new ProductModel()
            {
                ProductID = entity.ProductID,
                Title = entity.Title,
                Description = entity.Description,
                ImageURL = entity.ImageURL
            };
        }

        public static Product Convert(ProductModel model)
        {
            return new Product()
            {
                ProductID = model.ProductID,
                Title = model.Title,
                Description = model.Description,
                ImageURL = model.ImageURL
            };
        }
    }
}
