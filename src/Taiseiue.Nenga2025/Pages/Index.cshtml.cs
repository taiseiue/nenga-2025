using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taiseiue.Nenga2025.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public int Group { get; set; }

    [BindProperty]
    public int Number { get; set; }
    public bool WasPosted { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        WasPosted = false;
    }
    public void OnPost()
    {
        WasPosted = true;
    }
}
