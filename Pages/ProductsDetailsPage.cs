using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class ProductsDetailsPage(IPage page) : HomePage(page)
    {
        //private readonly string productPageUrl = "https://automationexercise.com/product_details/#";
        private readonly IPage page = page;
        public ILocator ProductDetails => page.Locator(".product-details");


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
