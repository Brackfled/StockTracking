using Application.Features.Customers.Rules;
using Application.Features.Products.Rules;
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
            private readonly ProductBusinessRules _productBusinessRules;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);

                await _productBusinessRules.CheckPropertiesHasAnyOneChanged(request, product);

                await _productRepository.UpdateAsync(product);

                UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

                return response;
            }
        }

    }

}
