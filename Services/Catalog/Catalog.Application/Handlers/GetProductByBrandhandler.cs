using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandhandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByBrandhandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProductsByBrand(request.BrandName);
            var productResponseList = ProductMapper.MapperExt.Map<IList<ProductResponse>>(productList);
            return productResponseList;
        }
    }
}