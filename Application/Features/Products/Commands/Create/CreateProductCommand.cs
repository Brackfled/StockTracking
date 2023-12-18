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

        public Guid BrandId { get; set; }
        public Guid SellerId { get; set; }
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int StockAmount { get; set; }

        public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreatedProductResponse> 
        {
        
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {

                Product product = _mapper.Map<Product>(request);
                product.Id = Guid.NewGuid();

                await _productRepository.AddAsync(product);


                CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

                return response;
                    
            }

        }

    }
}
