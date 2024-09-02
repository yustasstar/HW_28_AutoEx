using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class HomePage(IPage page) : BasePage(page)
    {
        private readonly string pageUrl = "https://automationexercise.com/";
        private readonly IPage page = page;

        public override string GetPageUrl()
        {
            return pageUrl;
        }
    }
}
