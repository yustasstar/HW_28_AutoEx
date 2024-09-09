using Microsoft.Playwright;
using System.Text.Json;

namespace HW_28_AutoEx.Setup
{
    public class GlobalSetup
    {
        private IAPIRequestContext _apiContext;
        private readonly string _userFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\user.json");

        [OneTimeSetUp]
        public async Task CreateAccount()
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            };

            IPlaywright playwrightDriver = await Playwright.CreateAsync();
            _apiContext = await playwrightDriver.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://automationexercise.com/api/",
                ExtraHTTPHeaders = headers,
            });

            if (!File.Exists(_userFilePath))
            {
                throw new FileNotFoundException($"Could not find 'user.json' file at {_userFilePath}");
            }

            var formDataFields = await LoadFormDataFieldsAsync();
            if (formDataFields == null)
            {
                Assert.Fail("Form data fields could not be loaded.");
                return;
            }

            var formDataCreate = _apiContext.CreateFormData();
            foreach (var field in formDataFields)
            {
                formDataCreate.Append(field.Key, field.Value);
            }

            var responseCreate = await _apiContext.PostAsync("createAccount", options: new() { Form = formDataCreate });
            var bodyCreate = await responseCreate.JsonAsync();
            var bodyCreateStatus = bodyCreate.Value.GetProperty("responseCode").GetInt32();
            var bodyCreateMessage = bodyCreate.Value.GetProperty("message").GetString();

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Status, Is.EqualTo(200));
                Assert.That(bodyCreateStatus, Is.EqualTo(201), $"{bodyCreateMessage}");
            });
        }

        [OneTimeTearDown]
        public async Task DeleteAccount()
        {
            if (!File.Exists(_userFilePath))
            {
                throw new FileNotFoundException($"Could not find 'user.json' file at {_userFilePath}");
            }

            var formDataFields = await LoadFormDataFieldsAsync();
            if (formDataFields == null || !formDataFields.TryGetValue("email", out var email) || !formDataFields.TryGetValue("password", out var password))
            {
                Assert.Fail("Email or password could not be retrieved from the JSON file.");
                return;
            }

            // Create and populate form data for deletion
            var formDataDelete = _apiContext.CreateFormData();
            formDataDelete.Append("email", email);
            formDataDelete.Append("password", password);

            // Send DELETE request to delete account
            var responseDelete = await _apiContext.DeleteAsync("deleteAccount", options: new() { Form = formDataDelete });
            var bodyDelete = await responseDelete.JsonAsync();
            var bodyDeleteStatus = bodyDelete.Value.GetProperty("responseCode").GetInt32();
            var bodyDeleteMessage = bodyDelete.Value.GetProperty("message").GetString();

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.Status, Is.EqualTo(200));
                Assert.That(bodyDeleteStatus, Is.EqualTo(200), $"{bodyDeleteMessage}");
            });

            await _apiContext.DisposeAsync();
        }

        private async Task<Dictionary<string, string>> LoadFormDataFieldsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_userFilePath);
            var formDataFields = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);

            // Handle the case where deserialization returns null
            return formDataFields ?? throw new InvalidOperationException("Deserialized form data fields are null.");
        }
    }
}