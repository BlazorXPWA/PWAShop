namespace ProPWAShop.Models.Orders
{
    using AutoMapper;

    using Data.Models;

    public class OrdersListingResponseModel : OrdersBaseResponseModel
    {
        public string ProductName { get; set; }
        public string ProductPackQuantity { get; set; }
        public string ProductQuantity { get; set; }
        public UnitsType ProductUnits { get; set; }
        public string ProductImageSource { get; set; }


        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<OrderProduct, OrdersListingResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(op => op.Order.Id))
                .ForMember(m => m.CreatedOn, m => m
                    .MapFrom(op => op.Order.CreatedOn.ToShortDateString()))
                .ForMember(m => m.ProductName, m => m
                    .MapFrom(op => op.Product.Name))
                .ForMember(m => m.ProductPackQuantity, m => m
                    .MapFrom(op => op.Quantity))
                .ForMember(m => m.ProductQuantity, m => m
                    .MapFrom(op => op.Product.InPack))
                .ForMember(m => m.ProductUnits, m => m
                    .MapFrom(op => op.Product.UnitsType))
                .ForMember(m => m.ProductImageSource, m => m
                    .MapFrom(o => o.Product.ImageSource));
    }
}
