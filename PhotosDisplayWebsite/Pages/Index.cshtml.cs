using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Pages
{
	public class IndexModel : PageModel
	{
        public string? Name { get; set; }
        public IList<PhotosDisplayWebsite.Models.Account> accounts { get; set; }
        public string? LoginResult { get; set; } = "Failed";
        //private readonly ILogger<IndexModel> _logger;
        private readonly PhotosDisplayWebsiteContext _context;

        public IndexModel(PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public void OnGet()
		{
            accounts = _context.Accounts.ToList();

            string? sessionId = Request.Cookies["sessionId"];
            if (sessionId != null)
            {
                var session = _context.Sessions.Where(val => val.Guid == sessionId).FirstOrDefault();

                if (session == null)
                {
                    return;
                }

                var val = _context.Accounts.Find(session.AccountUid).NickName;
                Name = val;
                LoginResult = "Success";
                ViewData["LoginState"] = "logged";
                ViewData["uid"] = session.AccountUid;
            }
        }
    }
}
