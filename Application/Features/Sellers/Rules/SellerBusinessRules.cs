using Application.Services.Repositories;
using Core.Application.Rules;
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
    }
}
