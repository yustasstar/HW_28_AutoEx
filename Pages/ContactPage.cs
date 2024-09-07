using Microsoft.Playwright;

namespace HW_28_AutoEx.Pages
{
    internal class ContactPage(IPage page) : HomePage(page)
    {
        //private readonly string pageUrl = "https://automationexercise.com/contact_us";
        private readonly IPage page = page;
        public ILocator NameInput => page.GetByPlaceholder("Name");
        public ILocator EmailInput => page.GetByPlaceholder("Email", new() { Exact = true });
        public ILocator SubjectInput => page.GetByPlaceholder("Subject");
        public ILocator MessageInput => page.GetByPlaceholder("Your Message Here"); 
        public ILocator UploadFileBtn => page.Locator("input[name='upload_file']");
        public ILocator SubmitBtn => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
        public ILocator HomeBtn => page.Locator("//*[@class='btn btn-success']"); 
        public ILocator SuccessMsg => page.Locator("//*[@class='status alert alert-success']");

        public async Task UploadFile()
        {
            await page.RunAndWaitForFileChooserAsync(async () => { await UploadFileBtn.ClickAsync(); });
            await UploadFileBtn.SetInputFilesAsync(new[] { "downloads/Test_Plan_Doc.pdf" });
        }

        public async Task DialogAccept()
        {
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await SubmitBtn.ClickAsync();
        }
    }
}
