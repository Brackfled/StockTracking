using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQuery:IRequest<GetByIdProductDto>
    {

        public Guid Id { get; set; }

        public class GetByIdProductQueryHandler: IRequestHandler<GetByIdProductQuery, GetByIdProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IBrandRepository _brandRepository;
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public GetByIdProductQueryHandler(IProductRepository productRepository, IBrandRepository brandRepository, ISellerRepository sellerRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _brandRepository = brandRepository;
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(predicate:p => p.Id == request.Id);

                Brand? brand = await _brandRepository.GetAsync(predicate: b=> b.Id == product.BrandId, withDeleted:true, cancellationToken:cancellationToken);
                Seller? seller = await _sellerRepository.GetAsync(predicate: s=> s.Id == product.SellerId, withDeleted:true, cancellationToken:cancellationToken);

                product.Brand = brand;
                product.Seller = seller;

                GetByIdProductDto response = _mapper.Map<GetByIdProductDto>(product);
                return response;
            }
        }

    }
}
