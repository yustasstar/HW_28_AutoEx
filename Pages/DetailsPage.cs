using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class DetailsPage(IPage page) : BasePage(page)
    {
        //private readonly string productPageUrl = "https://automationexercise.com/product_details/#";
        public ILocator ProductDetails => page.Locator(".product-details");
        public ILocator Quantity => page.Locator("#quantity");
        public ILocator AddBtn => page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" });


        public async Task VerifyProductsDetailsOpened()
        {
            await Assertions.Expect(ProductDetails).ToBeVisibleAsync();
        }

        public async Task VerifyProductsDetailsContentVisability()
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Blue Top" })).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Category: Women > Tops")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Rs. 500")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Availability: In Stock")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Condition: New")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Brand: Polo")).ToBeVisibleAsync();
        }
    }
}
