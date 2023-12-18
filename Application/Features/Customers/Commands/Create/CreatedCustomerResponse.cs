﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create
{
    public class CreatedCustomerResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
