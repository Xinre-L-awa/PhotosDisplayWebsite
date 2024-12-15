using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;
using PhotosDisplayWebsite.Utilities;

namespace PhotosDisplayWebsite.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly long _fileSizeLimit = 10000000000000;
        private readonly string[] _permittedExtensions = { ".jpg", ".png" };
        private readonly string _targetFilePath = "./wwwroot/_images";
        private readonly PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext _context;

        public CreateModel(PhotosDisplayWebsite.Data.PhotosDisplayWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Image Image { get; set; } = default!;
        [BindProperty]
        public ImageFilesUpload FileUpload { get; set; }
        public string Result { get; private set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //var formFileContent =
            //    await FileHelpers.ProcessFormFile<CreateModel>(
            //        FileUpload.FormFile, ModelState, _permittedExtensions,
            //        _fileSizeLimit);

            foreach (var formFile in FileUpload.FormFiles)
            {
                var formFileContent =
                    await FileHelpers
                        .ProcessFormFile<ImageFilesUpload>(
                            formFile, ModelState, _permittedExtensions,
                            _fileSizeLimit);

                var filePath = Path.Combine(
                    _targetFilePath, formFile.FileName);

                using (var fileStream = System.IO.File.Create(filePath))
                {
                    await fileStream.WriteAsync(formFileContent);

                    // To work directly with a FormFile, use the following
                    // instead:
                    //await FileUpload.FormFile.CopyToAsync(fileStream);
                }

                Image.FileUrl = $"_images/{formFile.FileName}";
                _context.Image.Add(new Image
                {
                    Title = Image.Title,
                    Uploader = Image.Uploader,
                    FileUrl = Image.FileUrl,
                    UploadTime = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }


        public class ImageFileUpload
        {
            [Required]
            [Display(Name = "Image")]
            public IFormFile? FormFile { get; set; }

            [Display(Name = "Note")]
            [StringLength(50, MinimumLength = 0)]
            public string? Note { get; set; }
        }

        public class ImageFilesUpload
        {
            [Required]
            [Display(Name = "File")]
            public List<IFormFile>? FormFiles { get; set; }

            [Display(Name = "Note")]
            [StringLength(50, MinimumLength = 0)]
            public string? Note { get; set; }
        }
    }
}
