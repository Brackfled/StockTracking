using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product:Entity<Guid>
    {

        public Guid BrandId { get; set; }
        public Guid SellerId { get; set; }
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int StockAmount { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Seller Seller { get; set; }

        public Product()
        {
            
        }

        public Product(Guid brandId, Guid sellerId, string name, string productDetail, int stockAmount)
        {
            BrandId = brandId;
            SellerId = sellerId;
            Name = name;
            ProductDetail = productDetail;
            StockAmount = stockAmount;
        }
    }
}
