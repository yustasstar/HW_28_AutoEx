using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace HW_28_AutoEx
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FirstTest : UITestFixture
    {
        [Test]
        public async Task HasTitle()
        {
            await Page.GotoAsync(baseUrl);
            await Assertions.Expect(Page).ToHaveTitleAsync(new Regex("Automation Exercise"));
        }

        [Test]
        public async Task GotoLogIn()
        {
            await Page.GotoAsync(baseUrl);
            await Page.GetByRole(AriaRole.Link, new() { Name = "Signup / Login" }).ClickAsync();
            await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Login to your account" })).ToBeVisibleAsync();
        } 
    }
}
