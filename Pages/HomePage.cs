using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class HomePage(IPage page) : BasePage(page)
    {
        private readonly IPage page = page;
        public ILocator CarouselIndicators => page.Locator(".carousel-indicators");

        public async Task VerifyCarouselIndicatorsVisability()
        {
            await Assertions.Expect(CarouselIndicators).ToBeVisibleAsync();
        }
    }
}
