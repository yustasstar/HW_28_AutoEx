using HW_28_AutoEx.Pages;
using HW_28_AutoEx.Setup;
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
        public void SetUp()
        {
            _homePage = new HomePage(Page!);
            _productsPage = new ProductsPage(Page!);
            _cartPage = new CartPage(Page!);
            _loginPage = new LoginPage(Page!);
            _contactPage = new ContactPage(Page!);
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

        //       Test Case 6: Contact Us Form
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

        //       Test Case 8: Verify All Products and product detail page
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click on 'Products' button
        //5. Verify user is navigated to ALL PRODUCTS page successfully
        //6. The products list is visible
        //7. Click on 'View Product' of first product
        //8. User is landed to product detail page
        //9. Verify that detail detail is visible: product name, category, price, availability, condition, brand

        //        Test Case 9: Search Product
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click on 'Products' button
        //5. Verify user is navigated to ALL PRODUCTS page successfully
        //6. Enter product name in search input and click search button
        //7. Verify 'SEARCHED PRODUCTS' is visible
        //8. Verify all the products related to search are visible

        //        Test Case 11: Verify Subscription in Cart page
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click 'Cart' button
        //5. Scroll down to footer
        //6. Verify text 'SUBSCRIPTION'
        //7. Enter email address in input and click arrow button
        //8. Verify success message 'You have been successfully subscribed!' is visible

        //        Test Case 13: Verify Product quantity in Cart
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click 'View Product' for any product on home page
        //5. Verify product detail is opened
        //6. Increase quantity to 4
        //7. Click 'Add to cart' button
        //8. Click 'View Cart' button
        //9. Verify that product is displayed in cart page with exact quantity

        //        Test Case 16: Place Order: Login before Checkout
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Click 'Signup / Login' button
        //5. Fill email, password and click 'Login' button
        //6. Verify 'Logged in as username' at top
        //7. Add products to cart
        //8. Click 'Cart' button
        //9. Verify that cart page is displayed
        //10. Click Proceed To Checkout
        //11. Verify Address Details and Review Your Order
        //12. Enter description in comment text area and click 'Place Order'
        //13. Enter payment details: Name on Card, Card Number, CVC, Expiration date
        //14. Click 'Pay and Confirm Order' button
        //15. Verify success message 'Your order has been placed successfully!'
        //16. Click 'Delete Account' button
        //17. Verify 'ACCOUNT DELETED!' and click 'Continue' button

        //        Test Case 17: Remove Products From Cart
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Verify that home page is visible successfully
        //4. Add products to cart
        //5. Click 'Cart' button
        //6. Verify that cart page is displayed
        //7. Click 'X' button corresponding to particular product
        //8. Verify that product is removed from the cart

        //        Test Case 22: Add to cart from Recommended items
        //1. Launch browser
        //2. Navigate to url 'http://automationexercise.com'
        //3. Scroll to bottom of page
        //4. Verify 'RECOMMENDED ITEMS' are visible
        //5. Click on 'Add To Cart' on Recommended product
        //6. Click on 'View Cart' button
        //7. Verify that product is displayed in cart page
    }
}
