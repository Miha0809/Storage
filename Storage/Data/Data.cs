using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Storage.Models;

namespace Storage
{
    public static class Datas
    {
        public static void Initialize(StorageContext storageContext)
        {
            if (storageContext == null)
            {
                throw new ArgumentNullException(nameof(storageContext));
            }

            if (!storageContext.Products.Any())
            {
                storageContext.Products.AddRange(
                    new Product()
                    {
                        Name = "Doll",
                        Price = 500
                    },
                    new Product()
                    {
                        Name = "Lego",
                        Price = 1000
                    },
                    new Product()
                    {
                        Name = "Tesla Model S Plaid+",
                        Price = 157490
                    },
                    new Product()
                    {
                        Name = "Tesla Model 3 Long Range",
                        Price = 58990
                    },
                    new Product()
                    {
                        Name = "Tesla Model X Plaid",
                        Price = 141990
                    },
                    new Product()
                    {
                        Name = "Tesla Model Y Long Range",
                        Price = 62490
                    }
                );

                storageContext.SaveChanges();
            }


            var products = new List<Product>();
            products.AddRange(storageContext.Products.ToList());

            if (!storageContext.Categories.Any())
            {
                storageContext.Categories.AddRange(
                    new Category()
                    {
                        Name = "Cars",
                        Products = products
                    },
                    new Category()
                    {
                        Name = "Toys"
                    }
                );

                storageContext.SaveChanges();
            }

            var product = new Product();
            product = storageContext.Products.Select(p => p).Where(p => p.Id == 1).FirstOrDefault();
            
            if (!storageContext.Orders.Any())
            {
                // storageContext.Orders.AddRange(
                //     new Order()
                //     {
                //         // User = "Mark",
                //         Address = "Nadvirna",
                //         Phone = "380963235503",
                //         OrderDateTime = DateTime.Now,
                //         Products = product
                //     }
                // );

                storageContext.SaveChanges();
            }
        }
    }
}