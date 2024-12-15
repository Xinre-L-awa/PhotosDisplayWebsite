using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Data;

namespace PhotosDisplayWebsite.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhotosDisplayWebsiteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PhotosDisplayWebsiteContext>>()))
            {
                if (context == null || context.Image == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (context.Image.Any())
                {
                    return;
                }

                context.Image.AddRange(
                    new Image
                    {
                        Title = "曹传雷",
                        Uploader = "Rainch_",
                        UploadTime = DateTime.Now,
                        FileUrl = "images/1.JPG",
                        Description = "2023级18班 班主任"
                    },
                    
                    new Image
                    {
                        Title = "图片2",
                        Uploader = "Rainch_",
                        UploadTime = DateTime.Now,
                        FileUrl = "images/2.JPG",
                        Description = ""
                    },

                    new Image
                    {
                        Title = "何中平",
                        Uploader = "Rainch_",
                        UploadTime = DateTime.Now,
                        FileUrl = "images/3.JPG",
                        Description = "2023级 年级主任，19班 班主任"
                    },

                    new Image
                    {
                        Title = "颁奖台",
                        Uploader = "Rainch_",
                        UploadTime = DateTime.Now,
                        FileUrl = "images/4.JPG",
                        Description = "2024运动会颁奖仪式"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
