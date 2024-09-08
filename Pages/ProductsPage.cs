using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class ProductsPage(IPage page) : HomePage(page)
    {
        //private readonly string productPageUrl = "https://automationexercise.com/products";
        private readonly IPage page = page;
        public ILocator ProductList => page.Locator(".features_items");
        public ILocator Product => page.Locator(".single-products");
        public ILocator SearchInput => page.GetByPlaceholder("Search Product");
        public ILocator SearchBtn => page.Locator("#submit_search");
        public ILocator ProductCardText => page.Locator("//*[@class='productinfo text-center']//p"); 



        public async Task VerifyProductsListVisability()
        {
            await Assertions.Expect(ProductList).ToBeVisibleAsync();
        }

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
