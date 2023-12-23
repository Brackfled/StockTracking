using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Queries.GetById
{
    public class GetByIdSellerQuery:IRequest<GetByIdSellerResponse>
    {

        public Guid Id { get; set; }

        public class GetByIdSellerQueryHandler: IRequestHandler<GetByIdSellerQuery, GetByIdSellerResponse>
        {
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public GetByIdSellerQueryHandler(ISellerRepository sellerRepository, IMapper mapper)
            {
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdSellerResponse> Handle(GetByIdSellerQuery request, CancellationToken cancellationToken)
            {
                Seller? seller = await _sellerRepository.GetAsync(predicate:s=>s.Id == request.Id);

                GetByIdSellerResponse response = _mapper.Map<GetByIdSellerResponse>(seller);
                return response;
            }
        }

    }
}
