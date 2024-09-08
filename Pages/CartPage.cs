using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class CartPage(IPage page) : HomePage(page)
    {
        //private readonly string cartPageUrl = "https://automationexercise.com/view_cart";
        private readonly IPage page = page;
        public ILocator CartSection => page.Locator(".active");
        public ILocator EmailInput => page.GetByPlaceholder("Your email address");
        public ILocator SubmitBtn => page.Locator("#subscribe");
        public ILocator SuccessMsg => page.Locator("#success-subscribe");

        public async Task TestNMethod()
        {
            await page.Locator(".choose > .nav > li > a").First.ClickAsync();
            await Assertions.Expect(page.Locator(".product-details")).ToBeVisibleAsync();

            await page.Locator("#quantity").FillAsync("4");
            await page.GetByRole(AriaRole.Button, new() { Name = " Add to cart" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Added!" })).ToBeVisibleAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "View Cart" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Button, new() { Name = "4" })).ToBeVisibleAsync();
        }
    }
}