using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class BrandsContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection) {
            bool checkBrands = brandCollection.Find(brand => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");
            if(!checkBrands) 
            {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if(brands != null) 
                {
                    foreach(var item in brands) 
                    {
                        brandCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}