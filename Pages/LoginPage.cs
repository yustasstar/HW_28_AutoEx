using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class LoginPage(IPage page) : BasePage(page)
    {
        //private readonly string loginPageUrl = "https://automationexercise.com/login";
        private readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
        //private ILocator ElementLocator2 => page.Locator("selector2");

    }
}
