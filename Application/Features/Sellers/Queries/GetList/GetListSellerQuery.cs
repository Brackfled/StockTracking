using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Queries.GetList
{
    public class GetListSellerQuery:IRequest<GetListResponse<GetListSellerListItemDto>>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListSellerRequestHandler:IRequestHandler<GetListSellerQuery, GetListResponse<GetListSellerListItemDto>>
        {
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public GetListSellerRequestHandler(ISellerRepository sellerRepository, IMapper mapper)
            {
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListSellerListItemDto>> Handle(GetListSellerQuery request, CancellationToken cancellationToken)
            {
                Paginate<Seller> sellers = await _sellerRepository.GetListAsync(
                        index:request.PageRequest.PageIndex,
                        size:request.PageRequest.PageSize,
                        withDeleted:true,
                        cancellationToken:cancellationToken
                    );

                GetListResponse<GetListSellerListItemDto> response = _mapper.Map<GetListResponse<GetListSellerListItemDto>>(sellers);

                return response;

            }
        }

    }
}
