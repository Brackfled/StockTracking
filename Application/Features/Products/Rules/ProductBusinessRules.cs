
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules:BaseBusinessRules
    {

        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CheckPropertiesHasAnyOneChanged(UpdateProductCommand request, Product product)
        {
            if (product == null)
                 throw new BusinessException(ProductsMessages.ProductIsNull);


            if (request.Name != null)
                product.Name = request.Name;
            if(request.ProductDetail != null)
                product.ProductDetail = request.ProductDetail;
            if (request.StockAmount != null)
                product.StockAmount = (int)request.StockAmount;

            return product;
        }

    }
}
