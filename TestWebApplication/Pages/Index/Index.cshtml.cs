using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestWebApplication.Pages.Hello;

public class Hello : PageModel
{
    public PageResult OnGet()
    {
        return Page();
    }
}