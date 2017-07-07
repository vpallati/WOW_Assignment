﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        //private string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["SchoolContext"];
        private bool outcome = false;
        /// <summary>
        /// Add Product.
        /// </summary>
        /// <param name="model"></param>
        public bool AddProduct(ProductModel model)
        {
            outcome = false;
            using (var context = new ProductEntity())
            {
                var entity = ProductModel.Convert(model);
                context.Products.Add(entity);
                outcome = context.SaveChanges() == 1;
            }

            return outcome;
        }

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateProduct(ProductModel model)
        {
            outcome = false;
            using (var context = new ProductEntity())
            {
                if(model != null)
                {
                    var entity = ProductModel.Convert(model);
                    context.Products.Attach(entity);
                    var entry = context.Entry(entity);

                    entry.Property(p => p.Title).IsModified = true;
                    entry.Property(p => p.Description).IsModified = true;
                    entry.Property(p => p.ImageURL).IsModified = true;

                    outcome = context.SaveChanges() == 1;
                }
            }

            return outcome;
        }

        /// <summary>
        /// Remove Product.
        /// </summary>
        /// <param name="model"></param>
        public bool RemoveProduct(ProductModel model)
        {
            outcome = false;
            using (var context = new ProductEntity())
            {
                if (model != null)
                {
                    var entity = ProductModel.Convert(model);
                    context.Products.Attach(entity);
                    context.Products.Remove(entity);
                    outcome = context.SaveChanges() == 1;
                }
            }

            return outcome;
        }

        /// <summary>
        /// Get All Products.
        /// </summary>
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> collection = new List<ProductModel>();
            using (var context = new ProductEntity())
            {
                context.Products.Add(new Product() {
                     Description = "",
                      ImageURL = "",
                       Title = ""
                });
                context.SaveChanges();
                collection.AddRange((context.Products.ToList().Select(a => ProductModel.Convert(a))));
            }

            return collection;
        }

        /// <summary>
        /// Get Products in Range.
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="EndIndex"></param>
        /// <returns></returns>
        public List<ProductModel> GetProductsInRange(int start, int end)
        {
            List<ProductModel> collection = new List<ProductModel>();
            using (var context = new ProductEntity())
            {
                collection.AddRange(context.Products.ToList().Select(a => ProductModel.Convert(a)));
            }

            return collection;
        }

        public ProductModel GetProduct(int id)
        {
            ProductModel product = null;
            using (var context = new ProductEntity())
            {
                var entity = context.Products.Where(a => a.ProductID == id).ToList().FirstOrDefault();
                product = ProductModel.Convert(entity);
            }

            return product;
        }

        /// <summary>
        /// Get Product Count .
        /// </summary>
        public int ProductCount()
        {
            int count = 0;
            using (var context = new ProductEntity())
            {
                count = context.Products.Count();
            }

            return count;
        }
    }
}
