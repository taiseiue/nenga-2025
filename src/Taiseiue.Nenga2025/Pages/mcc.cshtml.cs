using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Taiseiue.Nenga2025.Pages
{
    public class mccModel : PageModel
    {
        public Db db = new Db();
        public void OnGet()
        {
        }
    }
}
