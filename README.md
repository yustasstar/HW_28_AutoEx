# HW_28_AutoEx
The objective of the course project is to utilize the knowledge that has been acquired during the course.

1) Create a new project in your repository (Atata or Playwright with or without SpecFlow) to automate https://automationexercise.com/

2) Create a user through API in [OneTimeSetUp] and delete him in [OneTimeTearDown].
example of working with API https://automationexercise.com/api_list “API 11: POST To Create/Register User Account”, but here there is a peculiarity - the server accepts a request with form-data body.


Copy code:
    var headers = new Dictionary<string, string>();
    headers.Add("Accept", "application/json");

    var playwrightDriver = await Playwright.CreateAsync();
    var apiContext = await playwrightDriver.APIRequest.NewContextAsync(new()
{
    BaseURL = "https://automationexercise.com/api/",
    ExtraHTTPHeaders = headers,
});

    IFormData formDataCreate = apiContext.CreateFormData();
    formDataCreate.Append("name", "qawsed");
    formDataCreate.Append("email", "qawsed@asdf.asd");
    formDataCreate.Append("password", "qawsed");
    formDataCreate.Append("firstname", "firstname");
    formDataCreate.Append("lastname", "lastname");
    formDataCreate.Append("address1", "address1");
    formDataCreate.Append("country", "country");
    formDataCreate.Append("state", "state");
    formDataCreate.Append("city", "city");
    formDataCreate.Append("zipcode", "12345");
    formDataCreate.Append("mobile_number", "12345");

    IFormData formDataDelete = apiContext.CreateFormData();
    formDataDelete.Append("email", "qawsed@asdf.asd");
    formDataDelete.Append("password", "qawsed");

    var responseCreate = await apiContext.PostAsync("createAccount", options: new() { Form = formDataCreate });
    var responseDelete = await apiContext.DeleteAsync("deleteAccount", options: new() { Form = formDataDelete });

    Assert.That(responseCreate.Status, Is.EqualTo(200));
    Assert.That(responseCreate.Status, Is.EqualTo(200));

    var bodyCreate = await responseCreate.JsonAsync();
    var bodyDelete = await responseDelete.JsonAsync();
    var bodyStatusCreate = bodyCreate.Value.GetProperty("responseCode").GetInt32();
    var bodyStatusDelete = bodyDelete.Value.GetProperty("responseCode").GetInt32();
    Assert.That(bodyStatusCreate, Is.EqualTo(201));
    Assert.That(bodyStatusDelete, Is.EqualTo(200));

3) Save the user's session so that you don't have to log in every time (the test will be logged in through the UI)

4) Autimate  5 from 8 test cases (https://automationexercise.com/test_cases)

    Test Case 6: Contact Us Form
    Test Case 8: Verify All Products and product detail page
    Test Case 9: Search Product
    Test Case 11: Verify Subscription in Cart page
    Test Case 13: Verify Product quantity in Cart
    Test Case 16: Place Order: Login before Checkout (without  'Delete Account')
    Test Case 17: Remove Products From Cart
    Test Case 22: Add to cart from Recommended items

5) Use the recommendations from GP 18 and from https://github.com/OleksiiKhorunzhak/hilel-aqa/blob/main/CodeSmells/CodeSmells.cs

6) Provide the results of the work in the form of a Pull Request