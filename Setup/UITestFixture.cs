using HW_28_AutoEx.API;
using Microsoft.Playwright;
using System.Text;

namespace HW_28_AutoEx.Setup
{
    public class UITestFixture : GlobalSetup
    {
        private static IBrowser? Browser;
        internal static IBrowserContext? Context { get; private set; }
        internal static IPage? Page { get; private set; }

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            Browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var storagePath = "../../../playwright/.auth/state.json";
            FileInfo fileInfo = new(storagePath);

            if (!fileInfo.Exists)
            {
                Directory.CreateDirectory(fileInfo.Directory.FullName);
                using (FileStream fs = File.Create(storagePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine($"File '{storagePath}' created successfully.");
            }
            else
            {
                Console.WriteLine($"File '{storagePath}' already exists.");
            }

            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1885, Height = 945 },
                StorageStatePath = storagePath
            });

            await Context.Tracing.StartAsync(new()
            {
                Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            Page = await Context.NewPageAsync();
            Page.SetDefaultTimeout(15000);

            await Page.GotoAsync("https://automationexercise.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            //Page.PauseAsync();
            //await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                
            var navbarLocator = Page.Locator("//ul[@class='nav navbar-nav']");
            var isLogined = await navbarLocator.Locator("//a[contains(text(),'Logout')]").IsVisibleAsync();

            if (!isLogined)
            {
                await Page.Locator("//a[contains(text(),'Login')]").ClickAsync();
                await Page.Locator("[data-qa='login-email']").FillAsync("mailForTest123@test.com");
                await Page.Locator("[data-qa='login-password']").FillAsync("P@ssword123");
                await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
                await Assertions.Expect(Page.Locator("//a[contains(text(),'Logged in as')]")).ToBeVisibleAsync();
                await Context.StorageStateAsync(new() { Path = storagePath });
            }
        }

        [TearDown]
        public async Task Teardown()
        {
            var failed = TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Error || TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Failure;

            if (Context != null)
            {
                await Context.Tracing.StopAsync(new()
                {
                    Path = failed ? Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                ) : null,
                });
            }
            if (Page != null) { await Page.CloseAsync(); }
            if (Browser != null) { await Browser.CloseAsync(); }
        }
    }
}
