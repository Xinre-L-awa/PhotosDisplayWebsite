using System.ComponentModel.DataAnnotations;

namespace PhotosDisplayWebsite.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }
		public required string FileUrl { get; set; }
        [DataType(DataType.Date)]
		public DateTime UploadTime { get; set; }
		public required string Title { get; set; }
		public required string Uploader {  get; set; }
		public string? Description {  get; set; }
	}
}
