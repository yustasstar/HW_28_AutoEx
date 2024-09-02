using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class CartPage(IPage page) : BasePage(page)
    {
        private readonly string pageUrl = "https://automationexercise.com/login";
        private new readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
        //private ILocator ElementLocator2 => page.Locator("selector2");
        //private ILocator ElementLocator3 => page.Locator("selector3");

        public override string GetPageUrl()
        {
            return pageUrl;
        }
    }
}
