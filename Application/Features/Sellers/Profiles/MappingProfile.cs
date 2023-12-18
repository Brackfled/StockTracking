using Application.Features.Products.Queries.GetList;
using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Seller, CreateSellerCommand>().ReverseMap();
            CreateMap<Seller, CreatedSellerResponse>().ReverseMap();

            CreateMap<Seller, DeleteSellerCommand>().ReverseMap();
            CreateMap<Seller, DeletedSellerResponse>().ReverseMap();

            CreateMap<Seller, UpdateSellerCommand>().ReverseMap();
            CreateMap<Seller, UpdatedSellerResponse>().ReverseMap();

            CreateMap<Seller, GetListSellerListItemDto>().ReverseMap();
            CreateMap<Seller, GetListSellerQuery>().ReverseMap();
            CreateMap<Paginate<Seller>, GetListResponse<GetListSellerListItemDto>>().ReverseMap();
        }

    }
}
