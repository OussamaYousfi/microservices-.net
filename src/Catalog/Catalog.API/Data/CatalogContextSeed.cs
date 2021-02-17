using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> Products)
        {
            // Check existance of at least one product
            bool existProduct = Products.Find(p => true).Any();
            if(!existProduct)
            {
                Products.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "asd",
                    Description = "asd",
                    ImgFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Summary = "asd",
                    Description = "asd",
                    ImgFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Juawei Plus",
                    Summary = "asd",
                    Description = "asd",
                    ImgFile = "product-3.png",
                    Price = 650.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
