using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class CatalogContextSeed
    {
            public static void SeedData(IMongoCollection<Product> productCollection) {
            bool checkProducts = productCollection.Find(type => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if(!checkProducts) 
            {
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if(products != null) 
                {
                    foreach(var item in products) 
                    {
                        productCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}