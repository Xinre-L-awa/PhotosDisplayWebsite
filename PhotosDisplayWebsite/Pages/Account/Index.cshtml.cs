using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;
        public IndexModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }
        public bool IsNotFound = false;
        public PhotosDisplayWebsite.Models.Account Account { get; set; }

        public void OnGet(int? uid)
        {
            if (uid == null)
            {
                IsNotFound = true;
                return;
            }

            Account = _context.Accounts.Find(uid);
            if (Account == null)
            {
                IsNotFound = true;
                return;
            }
        }
    }
}
