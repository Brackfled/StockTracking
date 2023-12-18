using Application.Features.Brands.Commands.Update;
using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();

            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();

            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdatedCustomerResponse>().ReverseMap();

            CreateMap<Customer, GetListCustomerQuery>().ReverseMap();
            CreateMap<Customer, GetListCustomerListItemDto>().ReverseMap();
            CreateMap<Paginate<Customer>, GetListResponse<GetListCustomerListItemDto>>().ReverseMap();
        }

    }
}
