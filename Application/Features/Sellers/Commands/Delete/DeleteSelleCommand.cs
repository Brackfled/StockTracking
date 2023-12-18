using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Commands.Delete
{
    public class DeleteSellerCommand:IRequest<DeletedSellerResponse>
    {

        public Guid Id { get; set; }

        public class DeleteSellerCommandHandler: IRequestHandler<DeleteSellerCommand, DeletedSellerResponse>
        {
            private readonly ISellerRepository _sellerRepository;
            private readonly IMapper _mapper;

            public DeleteSellerCommandHandler(ISellerRepository sellerRepository, IMapper mapper)
            {
                _sellerRepository = sellerRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSellerResponse> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
            {
                Seller seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken:cancellationToken);

                await _sellerRepository.DeleteAsync(seller);

                DeletedSellerResponse response = _mapper.Map<DeletedSellerResponse>(seller);

                return response;

            }
        }
    }
}
