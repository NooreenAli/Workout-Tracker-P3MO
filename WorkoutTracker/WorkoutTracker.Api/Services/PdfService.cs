using Microsoft.Playwright;

namespace WorkoutTracker.Api.Services;

public class PdfService
{
    public async Task<byte[]> GeneratePdfAsync(string url)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(
            new() { Headless = true });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync(url, new()
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });

        await page.WaitForTimeoutAsync(1000);

        await page.EmulateMediaAsync(new()
        {
            Media = Media.Screen
        });

        await page.AddStyleTagAsync(new()
        {
            Content = @"
            * {
                -webkit-print-color-adjust: exact !important;
                print-color-adjust: exact !important;
            }
        "
        });

        var pdf = await page.PdfAsync(new()
        {
            Format = "A4",
            PrintBackground = true,
            Margin = new Margin
            {
                Top = "10mm",
                Bottom = "10mm",
                Left = "10mm",
                Right = "10mm"
            }
        });

        return pdf;
    }

}