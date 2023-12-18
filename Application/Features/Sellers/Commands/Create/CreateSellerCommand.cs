using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Commands.Create
{
    public class CreateSellerCommand:IRequest<CreatedSellerResponse>
    {

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }


        public class CreateSellerCommandHandler:IRequestHandler<CreateSellerCommand, CreatedSellerResponse>
        {

            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public CreateSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper)
            {
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSellerResponse> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
            {

                Seller seller = _mapper.Map<Seller>(request);
                seller.Id = Guid.NewGuid();

                await _sellerRepository.AddAsync(seller);

                CreatedSellerResponse response = _mapper.Map<CreatedSellerResponse>(seller);

                return response;

            }
        }

    }
}
