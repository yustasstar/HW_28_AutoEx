using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class CartPage(IPage page) : BasePage(page)
    {
        //private readonly string cartPageUrl = "https://automationexercise.com/view_cart";
        private readonly IPage page = page;
        public ILocator CartSection => page.Locator("#cart_items");
        //private ILocator ElementLocator2 => page.Locator("selector2");

    }
}
