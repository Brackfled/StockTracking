using Application.Features.Customers.Rules;
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
            private readonly CustomerBusinessRules _customerBusinessRules;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<UpdatedCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(predicate: c=> c.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);

               await _customerBusinessRules.CheckPropertiesHasAnyOneChanged(request,customer);

                await _customerRepository.UpdateAsync(customer);

                UpdatedCustomerResponse response = _mapper.Map<UpdatedCustomerResponse>(customer);

                return response;
            }
        }

    }
}
