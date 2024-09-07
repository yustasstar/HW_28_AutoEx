using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace HW_28_AutoEx.Pages
{
    internal class ProductsPage(IPage page) : BasePage(page)
    {
        //private readonly string productPageUrl = "https://automationexercise.com/products";
        private readonly IPage page = page;
        public ILocator ProductList => page.Locator(".features_items");
        public ILocator Product => page.Locator(".single-products");
        public ILocator ProductDetails => page.Locator(".product-details");
        public ILocator SearchInput => page.GetByPlaceholder("Search Product");
        public ILocator SearchBtn => page.Locator("#submit_search"); //*[@class='productinfo text-center']//p
        public ILocator ProductCardText => page.Locator("//*[@class='productinfo text-center']//p"); 



        public async Task VerifyProductsListVisability()
        {
            await Assertions.Expect(ProductList).ToBeVisibleAsync();
        }

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

        //8. Verify all the products related to search are visible

        public async Task VerifyAllProductsRelatedToSearch(string searchText)
        {
            var products = await ProductCardText.AllInnerTextsAsync();
            Assert.That(products, Is.Not.Null, $"No products on the page for '{searchText}' search text");
            Assert.That(products, Is.Not.Empty, $"No products on the page for '{searchText}' search text");

            foreach (var product in products)
            {
                var productLower = product.ToLower();
                var searchTextLower = searchText.ToLower();
                Assert.That(productLower, Does.Contain(searchTextLower), $"Product '{product}' does not contain the search text '{searchText}'");
            }
        }
    }
}
