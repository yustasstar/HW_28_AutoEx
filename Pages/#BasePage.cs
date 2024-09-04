using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal abstract class BasePage(IPage page)
    {
        private readonly IPage page = page;
        //private ILocator PageLinkLocator => page.Locator("//a[contains(text(),'Products')]");
        //private ILocator ElementLocator2 => page.Locator("selector2");
        //private ILocator ElementLocator3 => page.Locator("selector3");
    
        public abstract string GetPageUrl();

        public async Task GoToPage()
        {
            await page.GotoAsync(GetPageUrl(), new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
        }

        public async Task ClickPageLink(string linkName)
        {
            await page.GetByRole(AriaRole.Link).Filter(new() { HasText = $"{linkName}" }).ClickAsync();
        }

        public async Task VerifyPageHeading(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = $"{heading}" })).ToBeVisibleAsync();
        }

        public async Task VerifyTextVisible(string text)
        {
            await Assertions.Expect(page.GetByText(text)).ToBeVisibleAsync();
        }
    }
}
