using System.ComponentModel.DataAnnotations;

namespace PhotosDisplayWebsite.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        public required string Guid { get; set; }

        [Required]
        public required DateTime CreateTime { get; set; }

        [Required]
        public required int AccountUid { get; set; }

        // 单位: 天
        public int Duration { get; set; }
    }
}
