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

namespace Application.Features.Customers.Queries.GetList
{
    public class GetListCustomerQuery: IRequest<GetListResponse<GetListCustomerListItemDto>>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListCustomerQueryHandler: IRequestHandler<GetListCustomerQuery, GetListResponse<GetListCustomerListItemDto>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListCustomerListItemDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
            {
                Paginate<Customer> customers = await _customerRepository.GetListAsync(
                        size:request.PageRequest.PageSize,
                        index:request.PageRequest.PageIndex,
                        withDeleted:true,
                        cancellationToken:cancellationToken
                    );

                GetListResponse<GetListCustomerListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerListItemDto>>(customers);
                
                return response;

            }
        }

    }
}
