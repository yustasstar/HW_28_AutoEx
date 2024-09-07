using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class ProductsPage(IPage page) : BasePage(page)
    {
        //private readonly string productPageUrl = "https://automationexercise.com/products";
        private readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
        //private ILocator ElementLocator2 => page.Locator("selector2");

    }
}
