using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public interface IProductRepository
    {
        /// <summary>
        /// Add Product.
        /// </summary>
        /// <param name="model"></param>
        bool AddProduct(ProductModel model);

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="model"></param>
        bool UpdateProduct(ProductModel model);

        /// <summary>
        /// Remove Product.
        /// </summary>
        /// <param name="model"></param>
        bool RemoveProduct(ProductModel model);

        /// <summary>
        /// Get one Products.
        /// </summary>
        ProductModel GetProduct(int id);

        /// <summary>
        /// Get All Products.
        /// </summary>
        List<ProductModel> GetAllProducts();

        /// <summary>
        /// Get Product Count .
        /// </summary>
        int ProductCount();
    }
}
