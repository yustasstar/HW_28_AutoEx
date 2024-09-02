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

        [SetUp]
        public async Task SetUp()
        {
            _homePage = new HomePage(Page!);
            await _homePage.GoToPage();
        }

        [Test]
        public async Task GotoProductsPage()
        {
            await _homePage.ClickPageLink("Products");
            await _homePage.VerifyPageHeading("All Products");
        }

        [Test]
        public async Task GotoCartPage()
        {
            await _homePage.ClickPageLink("Cart");
            await _homePage.VerifyTextVisible("Shopping Cart");
        }

        [Test]
        public async Task GotoLoginPage()
        {
            await _homePage.ClickPageLink("Login"); // Signup / Login
            await _homePage.VerifyPageHeading("Login to your account");
        }

        [Test]
        public async Task GotoContactPage()
        {
            await _homePage.ClickPageLink("Contact us");
            await _homePage.VerifyPageHeading("Contact Us");
        }
    }
}
