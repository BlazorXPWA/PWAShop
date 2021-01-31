namespace ProPWAShop.Web.Client.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ProPWAShop.Data.Models;
    using ProPWAShop.Models.Users;
    using Models.ShoppingCarts;

    public partial class Cart
    {
        private readonly ShoppingCartRequestModel model = new ShoppingCartRequestModel();

        private decimal totalPrice;
        private decimal total;
        //private ProPWAShopUser user;
        private IEnumerable<ShoppingCartProductsResponseModel> cartProducts;
        private UsersListingResponseModel user;

        protected override async Task OnInitializedAsync() => await this.LoadDataAsync();

        private async Task LoadDataAsync()
        {
            this.user = await this.UsersService.GetCurrentUserData();
            this.cartProducts = await this.ShoppingCartsService.Mine();
            this.totalPrice = this.cartProducts.Sum(p => p.Price * p.Quantity);
            this.total = totalPrice*(100 - user.PersonalDiscountPercent)/100;
        }

        private async Task OnRemoveAsync(int productId)
        {
            await this.ShoppingCartsService.RemoveProduct(productId);

            this.NavigationManager.NavigateTo("/cart", forceLoad: true);
        }

        private async Task IncrementQuantity(int productId, int quantity, int stockQuantity)
        {
            this.model.ProductId = productId;
            this.model.Quantity = quantity;

            if (this.model.Quantity + 1 <= stockQuantity)
            {
                this.model.Quantity++;

                await this.ShoppingCartsService.UpdateProduct(this.model);
                await this.LoadDataAsync();
            }
        }

        private async Task DecrementQuantity(int productId, int quantity)
        {
            this.model.ProductId = productId;
            this.model.Quantity = quantity;

            if (this.model.Quantity - 1 > 0)
            {
                this.model.Quantity--;

                await this.ShoppingCartsService.UpdateProduct(this.model);
                await this.LoadDataAsync();
            }
        }
    }
}
