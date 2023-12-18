using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand: IRequest<CreatedCustomerResponse>
    {

        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer customer = _mapper.Map<Customer>(request);
                customer.Id = Guid.NewGuid();

                await _customerRepository.AddAsync(customer);

                CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(customer);

                return response;

            }
        }



    }
}
