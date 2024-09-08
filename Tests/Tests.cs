using HW_28_AutoEx.Pages;
using HW_28_AutoEx.Setup;
using NUnit.Framework.Internal;


namespace HW_28_AutoEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : UITestFixture
    {
        private HomePage _homePage;
        private ProductsPage _productsPage;
        private DetailsPage _detailsPage;
        private CartPage _cartPage;
        //private LoginPage _loginPage;
        private ContactPage _contactPage;

        [SetUp]
        public void TestSetUp()
        {
            _homePage = new HomePage(Page!);
            _productsPage = new ProductsPage(Page!);
            _detailsPage = new DetailsPage(Page!);
            _cartPage = new CartPage(Page!);
            //_loginPage = new LoginPage(Page!);
            _contactPage = new ContactPage(Page!);
        }

        [Description("Test Case 6: Contact Us Form")]
        [Test]
        public async Task ContactUsForm()
        {
            //3.Verify that home page is visible successfully
            await _homePage.VerifyCarouselIndicatorsVisability();
            //4.Click on 'Contact Us' button
            await _homePage.ClickLinkBtn("Contact us");
            //5.Verify 'GET IN TOUCH' is visible
            await _contactPage.VerifyPageHeading("GET IN TOUCH");
            //6.Enter name, email, subject and message
            await _contactPage.NameInput.FillAsync("TestName");
            await _contactPage.EmailInput.FillAsync("TestEmail123@mail.com");
            await _contactPage.SubjectInput.FillAsync("Subject is testing");
            await _contactPage.MessageInput.FillAsync("it's a super test Message");
            //7.Upload file
            await _contactPage.UploadFile();
            //8.Click 'Submit' button
            await _contactPage.SubmitBtn.ClickAsync();
            //9.Click OK button
            await _contactPage.DialogAccept();
            //10.Verify success message 'Success! Your details have been submitted successfully.' is visible
            await _contactPage.VerifyLocatorHaveText(_contactPage.SuccessMsg, "Success! Your details have been submitted successfully.");
            //11.Click 'Home' button and verify that landed to home page successfully
            await _contactPage.HomeBtn.ClickAsync();
            await _homePage.VerifyCarouselIndicatorsVisability();
        }

        [Description("Test Case 8: Verify All Products and product detail page")]
        [Test]
        public async Task ProductDetailsContent()
        {
            //3.Verify that home page is visible successfully
            await _homePage.VerifyCarouselIndicatorsVisability();
            //4. Click on 'Products' button
            await _homePage.ClickLinkBtn("Products");
            //5. Verify user is navigated to ALL PRODUCTS page successfully
            await _productsPage.VerifyPageHeading("All Products");
            //6. The products list is visible
            await _productsPage.VerifyProductsListVisability();
            //7. Click on 'View Product' of first product
            await _productsPage.ClickLinkBtn("View Product");
            //8. User is landed to product detail page
            await _detailsPage.VerifyProductsDetailsOpened();
            //9. Verify that product detail is visible: product name, category, price, availability, condition, brand
            await _detailsPage.VerifyProductsDetailsContentVisability();
        }

        [Description("Test Case 9: Search Product")]
        [Test]
        public async Task SearchProduct()
        {
            var searchText = "cotton";

            //3.Verify that home page is visible successfully
            await _homePage.VerifyCarouselIndicatorsVisability();
            //4. Click on 'Products' button
            await _homePage.ClickLinkBtn("Products");
            //5. Verify user is navigated to ALL PRODUCTS page successfully
            await _productsPage.VerifyPageHeading("All Products");
            //6. Enter product name in search input and click search button
            await _productsPage.SearchInput.FillAsync(searchText);
            await _productsPage.SearchBtn.ClickAsync();
            //7. Verify 'SEARCHED PRODUCTS' is visible
            await _productsPage.VerifyPageHeading("SEARCHED PRODUCTS");
            //8. Verify all the products related to search are visible 
            await _productsPage.VerifyAllProductsRelatedToSearch(searchText);

        }      

        [Description("Test Case 11: Verify SubscriptionInCart in Cart page")]
        [Test]
        public async Task SubscriptionInCart()
        {
            //3.Verify that home page is visible successfully
            await _homePage.VerifyCarouselIndicatorsVisability();
            //4. Click 'Cart' button
            await _homePage.ClickLinkBtn("Cart");
            //5. Scroll down to footer
            //6. Verify text 'SUBSCRIPTION'
            await _cartPage.VerifyPageHeading("SUBSCRIPTION");
            //7. Enter email address in input and click arrow button 
            await _cartPage.EmailInput.FillAsync("TestEmail123@mail.com");
            await _cartPage.SubmitBtn.ClickAsync();
            //8. Verify success message 'You have been successfully subscribed!' is visible
            await _cartPage.VerifyLocatorHaveText(_cartPage.SuccessMsg, "You have been successfully subscribed!");
        }
       
        [Description("Test Case 13: Verify Product quantity in Cart")]
        [Test]
        public async Task ProductQuantityInCart()
        {
            //3.Verify that home page is visible successfully
            await _homePage.VerifyCarouselIndicatorsVisability();
            //4. Click 'View Product' for any product on home page
            await _homePage.ClickLinkBtn("View Product");
            //5. Verify product detail is opened
            await _detailsPage.VerifyProductsDetailsOpened();
            //6. Increase quantity to 4
            await _detailsPage.Quantity.FillAsync("4");
            //7. Click 'Add to cart' button
            await _detailsPage.AddBtn.ClickAsync();
            //8. Click 'View Cart' button
            await _detailsPage.ClickLinkBtn("View Cart");
            //9. Verify that product is displayed in cart page with exact quantity
            await _cartPage.VerifyProductQuantity("4");
        }


        //        Test Case 16: Place Order: Login before Checkout

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

        //3. Verify that home page is visible successfully
        //4. Add products to cart
        //5. Click 'Cart' button
        //6. Verify that cart page is displayed
        //7. Click 'X' button corresponding to particular product
        //8. Verify that product is removed from the cart

        //        Test Case 22: Add to cart from Recommended items

        //3. Scroll to bottom of page
        //4. Verify 'RECOMMENDED ITEMS' are visible
        //5. Click on 'Add To Cart' on Recommended product
        //6. Click on 'View Cart' button
        //7. Verify that product is displayed in cart page
    }
}
