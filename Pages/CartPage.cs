using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class CartPage(IPage page) : BasePage(page)
    {
        //private readonly string cartPageUrl = "https://automationexercise.com/view_cart";
        public ILocator EmailInput => page.GetByPlaceholder("Your email address");
        public ILocator SubmitBtn => page.Locator("#subscribe");
        public ILocator SuccessMsg => page.Locator("#success-subscribe");
        public ILocator Quantity => page.Locator(".cart_quantity");


        public async Task VerifyProductQuantity(string quantity)
        {
            await Assertions.Expect(Quantity).ToHaveTextAsync(quantity);
        }
    }
}