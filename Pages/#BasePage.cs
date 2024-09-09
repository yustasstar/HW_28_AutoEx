using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal abstract class BasePage(IPage page)
    {
        private readonly IPage page = page;

        public async Task ClickLinkBtn(string linkName)
        {
            await page.GetByRole(AriaRole.Link).Filter(new() { HasText = $"{linkName}" }).First.ClickAsync();
        }

        public async Task VerifyPageHeading(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = $"{heading}" })).ToBeVisibleAsync();
        }

        public async Task VerifyLocatorHaveText(ILocator locator, string text)
        {
            await Assertions.Expect(locator).ToHaveTextAsync(text);
        }
    }
}
