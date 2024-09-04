using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class LoginPage(IPage page) : BasePage(page)
    {
        public readonly string loginPageUrl = "https://automationexercise.com/products";
        private readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
        //private ILocator ElementLocator2 => page.Locator("selector2");
        //private ILocator ElementLocator3 => page.Locator("selector3");

        public override string GetPageUrl()
        {
            return loginPageUrl;
        }
    }
}
