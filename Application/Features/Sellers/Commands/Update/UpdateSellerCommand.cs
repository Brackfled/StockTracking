using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Commands.Update
{
    public class UpdateSellerCommand: IRequest<UpdatedSellerResponse>
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }

        public class UpdateSellerCommandHandler: IRequestHandler<UpdateSellerCommand, UpdatedSellerResponse>
        {
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;
            private readonly SellerBusinessRules _sellerBusinessRules;

            public UpdateSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper, SellerBusinessRules sellerBusinessRules)
            {
                _sellerRepository = sellerRepository;
                _mapper = mapper;
                _sellerBusinessRules = sellerBusinessRules;
            }

            public async Task<UpdatedSellerResponse> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
            {
                Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken:cancellationToken);

                await _sellerBusinessRules.CheckPropertiesHasAnyOneChanged(request, seller);

                //if (request.Name != null)
                //    seller.Name = request.Name;
                //if (request.PhoneNumber != null)
                //    seller.PhoneNumber = request.PhoneNumber;
                //if (request.Email != null)
                //    seller.Email = request.Email;
                //if (request.Adress != null)
                //    seller.Adress = request.Adress;

                await _sellerRepository.UpdateAsync(seller);

                UpdatedSellerResponse response = _mapper.Map<UpdatedSellerResponse>(seller);

                return response;
            }
        }

    }
}
