using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Images
{
    public class DetailsModel : PageModel
    {
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;

        public DetailsModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public Image Image { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image.FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            else
            {
                Image = image;
            }
            return Page();
        }
    }
}
