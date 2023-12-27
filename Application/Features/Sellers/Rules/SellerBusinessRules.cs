
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Rules
{
    public class SellerBusinessRules: BaseBusinessRules
    {

        private readonly ISellerRepository _sellerRepository;

        public SellerBusinessRules(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<Seller> CheckPropertiesHasAnyOneChanged(UpdateSellerCommand request, Seller seller)
        {
            if (seller == null)
                throw new BusinessException(SellersMessages.SellerIsNull);


            if (request.Name != null)
                seller.Name = request.Name;
            if (request.PhoneNumber != null)
                seller.PhoneNumber = request.PhoneNumber;
            if (request.Email != null)
                seller.Email = request.Email;
            if (request.Adress != null)
                seller.Adress = request.Adress;

            return seller;
        }

    }
}
