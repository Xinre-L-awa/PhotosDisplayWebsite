using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Account
{
    public class RegisterPageModel : PageModel
    {
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;

        public RegisterPageModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PhotosDisplayWebsite.Models.Account NewAccount { get; set; } = default!;

        public string Result { get; set; } = string.Empty;
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //  Verify
            foreach (var account in _context.Accounts)
            {
                if (account.NickName == NewAccount.NickName)
                {
                    Result = "该用户名已存在！";
                    return Page();
                }

            }

            NewAccount.CreateTime = DateTime.Now;
            _context.Accounts.Add(NewAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
