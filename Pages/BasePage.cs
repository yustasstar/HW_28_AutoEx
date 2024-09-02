using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal abstract class BasePage(IPage page)
    {
        internal IPage page = page;

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
