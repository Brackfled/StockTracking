using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdatedProductResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ProductDetail { get; set; }
        public int? StockAmount { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);

                if(request.Name != null)
                    product.Name= request.Name;
                if(request.ProductDetail != null)
                    product.ProductDetail = request.ProductDetail;
                if(request.StockAmount != null)
                    product.StockAmount = (int)request.StockAmount;


                await _productRepository.UpdateAsync(product);

                UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

                return response;
            }
        }

    }

}
