using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class HomePage(IPage page)
    {
        private readonly IPage page = page;
        public ILocator CarouselIndicators => page.Locator(".carousel-indicators");
        //private ILocator ElementLocator2 => page.Locator("selector2");

        public async Task ClickOnLink(string linkName)
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

        public async Task VerifyCarouselIndicatorsVisability()
        {
            await Assertions.Expect(CarouselIndicators).ToBeVisibleAsync();
        }
    }
}
