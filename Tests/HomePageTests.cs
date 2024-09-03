using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using HW_28_AutoEx.Pages;
using HW_28_AutoEx.Setup;
using Microsoft.Playwright;
using NUnit.Framework.Internal;

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

        //Test Case 6: Contact Us Form

        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click on 'Contact Us' button
        //5. Verify 'GET IN TOUCH' is visible
        //6. Enter name, email, subject and message
        //7. Upload file
        //8. Click 'Submit' button
        //9. Click OK button
        //10. Verify success message 'Success! Your details have been submitted successfully.' is visible
        //11. Click 'Home' button and verify that landed to home page successfully
    }
}
