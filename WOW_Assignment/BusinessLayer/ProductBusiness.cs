using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.DataAccess;

namespace BusinessLayer
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _productRepository;

        public ProductBusiness()
        {
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Add Product.
        /// </summary>
        /// <param name="model"></param>
        public bool AddProduct(ProductModel model)
        {
            var feedback = false;
            if(model != null)
            {
                feedback = _productRepository.AddProduct(model);
            }
            return feedback;
        }

        /// <summary>
        /// Get All Products.
        /// </summary>
        public List<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get one Products.
        /// </summary>
        public ProductModel GetProduct(int id)
        {
            ProductModel model = null;
            if(id < _productRepository.ProductCount())
            {
                model = _productRepository.GetProduct(id);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            return model;
        }

        /// <summary>
        /// Get Products in Range.
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="EndIndex"></param>
        /// <returns></returns>
        public List<ProductModel> GetProductsInRange(int start, int end)
        {
            List<ProductModel> collection = null;
            var count = _productRepository.ProductCount();

            if((start > 0) && (end > 0) && (end >= start))
            {
                if (end >= count)
                    end = count - 1;
                collection = _productRepository.GetProductsInRange(start, end);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            return collection;            
        }

        /// <summary>
        /// Remove Product.
        /// </summary>
        /// <param name="model"></param>
        public bool RemoveProduct(ProductModel model)
        {
            var feedback = false;
            if (model != null)
            {
                feedback = _productRepository.RemoveProduct(model);
            }
            return feedback;
        }

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateProduct(ProductModel model)
        {
            var feedback = false;
            if (model != null)
            {
                feedback = _productRepository.UpdateProduct(model);
            }
            return feedback;
        }
    }
}
