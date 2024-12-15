using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;
        public DeleteModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhotosDisplayWebsite.Models.Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? uid)
        {
            if (uid == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Uid == uid);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? uid)
        {
            if (uid == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(uid);
            if (account != null)
            {
                Account = account;
                _context.Accounts.Remove(Account);
                await _context.SaveChangesAsync();

                Response.Cookies.Delete("SessionId");
                var sessions = 
                    from session in _context.Sessions
                    where session.AccountUid == account.Uid
                    select session;
                _context.Sessions.RemoveRange(sessions);
            }

            return Redirect("~/");
        }
    }
}
