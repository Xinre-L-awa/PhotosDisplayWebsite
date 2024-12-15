using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Images
{
    public class EditModel : PageModel
    {
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;

        public EditModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Image Image { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image =  await _context.Image.FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            Image = image;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(Image.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.Id == id);
        }
    }
}
