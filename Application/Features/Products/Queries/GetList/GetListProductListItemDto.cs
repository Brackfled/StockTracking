﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetList
{
    public class GetListProductListItemDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string SellerName { get; set; }
        public string ProductDetail { get; set; }
        public int   StockAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
