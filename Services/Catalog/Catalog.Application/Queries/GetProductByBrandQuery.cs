using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByBrandQuery : IRequest<IList<ProductResponse>>
    {
        public string BrandName { get; set; }
        public GetProductByBrandQuery(string brandName)
        {
            BrandName = brandName;
            
        }
    }
}