using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly int max_count = 20;
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;

        public IndexModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Title { get; set; }


        
        public async Task OnGetAsync()
        {
            int current_page_index = Request.Query["page"].IsNullOrEmpty() ? 1 : Convert.ToInt32(Request.Query["page"]);
            ViewData["page_index"] = current_page_index;
            ViewData["display_mode"] = Convert.ToInt32(Request.Query["display_mode"]);
            ViewData["SearchString"] = SearchString;

            var images = from image in _context.Image
                         select image;
            int images_count = images.Count();

            ViewData["page_amount"] = Math.Ceiling((decimal)images_count / max_count);

            if (!string.IsNullOrEmpty(SearchString))
            {
                Image = await images
                    .Where(val => val.Title.Contains(SearchString))
                    .ToListAsync();
            }
            else Image = await _context.Image.ToListAsync();

            if (Image.Count > max_count)
            {
                int k = max_count * (current_page_index - 1);
                IList<Image> res = [];
                for (int i = k; i < k + max_count && i < Image.Count; i++)
                {
                    Console.WriteLine(i);
                    res.Add(Image[i]);
                }
                Image = res;
            }
        }
    }
}
