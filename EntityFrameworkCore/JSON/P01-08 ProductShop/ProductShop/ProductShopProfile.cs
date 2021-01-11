using AutoMapper;
using ProductShop.DTO.Category;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ListProductsInRangeDTO>()
                .ForMember(x => x.SellerName, y => y.MapFrom(s => s.Seller.FirstName + " " + s.Seller.LastName));

            this.CreateMap<Product, UserSoldProductDTO>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(s => s.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<User, SoldProductWithBuyerInfoDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold.Where(p => p.Buyer != null)));

            this.CreateMap<Category, CategoriesByProductCountDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.ProductsCount, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(c => (c.CategoryProducts.Count * c.CategoryProducts.Average(cp => cp.Product.Price)).ToString("F2")));
        }
    }
}
