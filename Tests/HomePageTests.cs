using System.Text.RegularExpressions;
using HW_28_AutoEx.Pages;
using Microsoft.Playwright;

namespace HW_28_AutoEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class HomePageTests : UITestFixture
    {
        private HomePage _homePage;
        private ProductsPage _productsPage;
        private CartPage _cartPage;
        private LoginPage _loginPage;
        private ContactPage _contactPage;

        [SetUp]
        public async Task SetUp()
        {
            _homePage = new HomePage(Page!);
            _productsPage = new ProductsPage(Page!);
            _cartPage = new CartPage(Page!);
            _loginPage = new LoginPage(Page!);
            _contactPage = new ContactPage(Page!);
            await _homePage.GoToPage();
        }

        [Test]
        public async Task GotoProductsPage()
        {
            await _homePage.ClickPageLink("Products");
            await _productsPage.VerifyPageHeading("All Products");
        }

        [Test]
        public async Task GotoCartPage()
        {
            await _homePage.ClickPageLink("Cart");
            await _cartPage.VerifyTextVisible("Shopping Cart");
        }

        [Test]
        public async Task GotoLoginPage()
        {
            await _homePage.ClickPageLink("Login");
            await _loginPage.VerifyPageHeading("Login to your account");
        }

        [Test]
        public async Task GotoContactPage()
        {
            await _homePage.ClickPageLink("Contact us");
            await _contactPage.VerifyPageHeading("Contact Us");
        }
    }
}
