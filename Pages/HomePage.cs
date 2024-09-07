using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class HomePage(IPage page) : BasePage(page)
    {
        //private readonly string homePageUrl = "https://automationexercise.com/";
        private readonly IPage page = page;
        public ILocator CarouselIndicators => page.Locator(".carousel-indicators");
        //private ILocator ElementLocator2 => page.Locator("selector2");

        public async Task VerifyCarouselIndicatorsVisability()
        {
            await Assertions.Expect(CarouselIndicators).ToBeVisibleAsync();
        }
    }
}
