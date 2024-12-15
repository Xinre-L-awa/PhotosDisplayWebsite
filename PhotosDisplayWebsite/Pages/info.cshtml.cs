using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhotosDisplayWebsite.Pages
{
    public class infoModel : PageModel
    {
        public void OnGet()
        {
            string img = Convert.ToString(Request.Query["name"]);
            ViewData["img"] = img;
        }
    }
}
