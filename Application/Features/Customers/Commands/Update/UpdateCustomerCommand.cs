using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand: IRequest<UpdatedCustomerResponse>
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }

        public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, UpdatedCustomerResponse>
        {

            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(predicate: c=> c.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);

                if (request.Name != null)
                    customer.Name = request.Name;
                if (request.CompanyName != null)
                    customer.CompanyName = request.CompanyName;
                if (request.Email != null)
                    customer.Email = request.Email;
                if (request.PhoneNumber != null)
                    customer.PhoneNumber = request.PhoneNumber;
                if(request.Adress != null)
                    customer.Adress = request.Adress;

                await _customerRepository.UpdateAsync(customer);

                UpdatedCustomerResponse response = _mapper.Map<UpdatedCustomerResponse>(customer);

                return response;
            }
        }

    }
}
