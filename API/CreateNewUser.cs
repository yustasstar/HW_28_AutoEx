using Microsoft.Playwright;

namespace HW_28_AutoEx.API
{
    internal class CreateNewUser
    {
        private readonly IAPIRequestContext _apiContext;
        private readonly string _userEmail = "mailForTest123@test.com";
        private readonly string _userPassword = "P@ssword123";

        [OneTimeSetUp]
        public async Task CreateAccount()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            var playwrightDriver = await Playwright.CreateAsync();
            var apiContext = await playwrightDriver.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://automationexercise.com/api/",
                ExtraHTTPHeaders = headers,
            });

            IFormData formDataCreate = _apiContext.CreateFormData();
            formDataCreate.Append("name", "TestName");
            formDataCreate.Append("email", _userEmail);
            formDataCreate.Append("password", _userPassword);
            formDataCreate.Append("title", "Mr");
            formDataCreate.Append("birth_date", "Mr");
            formDataCreate.Append("birth_month", "Mr");
            formDataCreate.Append("birth_year", "Mr");
            formDataCreate.Append("firstname", "FirstName");
            formDataCreate.Append("lastname", "LastName");
            formDataCreate.Append("company", "TestCORP");
            formDataCreate.Append("address1", "Test Address 1");
            formDataCreate.Append("address2", "Test Address 2");
            formDataCreate.Append("country", "UA");
            formDataCreate.Append("state", "OD");
            formDataCreate.Append("city", "Odessa");
            formDataCreate.Append("zipcode", "65000");
            formDataCreate.Append("mobile_number", "+380671234567");

            var responseCreate = await apiContext.PostAsync("createAccount", options: new() { Form = formDataCreate });
            var bodyCreate = await responseCreate.JsonAsync();
            var bodyStatusCreate = bodyCreate.Value.GetProperty("responseCode").GetInt32();

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Status, Is.EqualTo(200));
                Assert.That(bodyStatusCreate, Is.EqualTo(201));
            });
        }

        [OneTimeTearDown]
        public async Task DeleteAccount()
        {
            IFormData formDataDelete = _apiContext.CreateFormData();
            formDataDelete.Append("email", _userEmail);
            formDataDelete.Append("password", _userPassword);

            var responseDelete = await _apiContext.DeleteAsync("deleteAccount", options: new() { Form = formDataDelete });
            var bodyDelete = await responseDelete.JsonAsync();
            var bodyStatusDelete = bodyDelete.Value.GetProperty("responseCode").GetInt32();

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.Status, Is.EqualTo(200));
                Assert.That(bodyStatusDelete, Is.EqualTo(200));
            });
        }
    }
}
