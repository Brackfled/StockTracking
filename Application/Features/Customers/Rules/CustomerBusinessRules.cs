﻿using Application.Services.Repositories;
using Core.Application.Rules;
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
    }
}
