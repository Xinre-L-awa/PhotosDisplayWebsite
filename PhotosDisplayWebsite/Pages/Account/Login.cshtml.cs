using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages.Account
{
    public class LoginModel : PageModel
    {
        public int Duration { get; set; } = 5;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;
        public LoginModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public string Result { get; set; } = "Success";

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return Page();
            }

            foreach (var account in await _context.Accounts.ToListAsync())
            {
                if (account.NickName == Username)
                {
                    if (account.Password != Password)
                    {
                        Result = "√‹¬Î¥ÌŒÛ";
                        return Page();
                    }

                    Session session = new()
                    {
                        Guid = Guid.NewGuid().ToString(),
                        AccountUid = account.Uid,
                        CreateTime = DateTime.Now,
                        Duration = Duration
                    };
                    _context.Sessions.Add(session);
                    _context.SaveChanges();
                    Response.Cookies.Append("SessionId", session.Guid);

                    Console.WriteLine(Result);

                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
