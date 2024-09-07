using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class ApiPage(IPage page) : HomePage(page)
    {
        //private readonly string pageUrl = "https://automationexercise.com/api_list";
        private readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
    }
}
