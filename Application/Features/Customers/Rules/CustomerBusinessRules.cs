using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules:BaseBusinessRules
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CheckPropertiesHasAnyOneChanged(UpdateCustomerCommand request, Customer customer)
        {
            if (customer == null)
                throw new BusinessException(CustomersMessages.CustomerIsNull);

            if(request.Name != null)
                customer.Name = request.Name;
            if(request.CompanyName != null)
                customer.CompanyName = request.CompanyName;
            if(request.Email != null)
                customer.Email = request.Email;
            if (request.PhoneNumber != null)
                customer.PhoneNumber = request.PhoneNumber;
            if(request.Adress != null)
                customer.Adress = request.Adress;

            return customer;
        }

    }
}
