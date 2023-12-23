using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand:IRequest<CreatedProductResponse>
    {

        public string BrandName{ get; set; }
        public string SellerName { get; set; }
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int StockAmount { get; set; }

        public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreatedProductResponse> 
        {
        
            private readonly IProductRepository _productRepository;
            private readonly IBrandRepository _brandRepository;
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IBrandRepository brandRepository, ISellerRepository sellerRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _brandRepository = brandRepository;
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {

                Product product = _mapper.Map<Product>(request);
                product.Id = Guid.NewGuid();

                Brand brand = await _brandRepository.GetAsync(predicate: b=> b.Name == request.BrandName);
                Seller seller = await _sellerRepository.GetAsync(predicate:s => s.Name == request.SellerName);

                product.Brand = brand;
                product.Seller = seller;

                await _productRepository.AddAsync(product);

                CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);
                return response;

               
                    
            }

        }

    }
}
