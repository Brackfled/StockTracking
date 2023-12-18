using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, DeletedProductResponse>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();

            CreateMap<UpdateProductCommand, Product>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
                
            CreateMap<Product, UpdatedProductResponse>().ReverseMap();

            CreateMap<Product, GetListProductListItemDto>()
                .ForMember(destinationMember:p => p.BrandName, memberOptions: opt=> opt.MapFrom(p => p.Brand.Name))
                .ForMember(destinationMember: p => p.SellerName, memberOptions: opt => opt.MapFrom(p => p.Seller.Name))
                .ReverseMap();
            CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();

        }

    }
}
