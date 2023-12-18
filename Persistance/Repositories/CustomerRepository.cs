using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Domain.Entities;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CustomerRepository:EfRepositoryBase<Customer, Guid, BaseDbContext>, ICustomerRepository
    {
        public CustomerRepository(BaseDbContext context):base(context) 
        {
            
        }
    }
}
