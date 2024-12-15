using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhotosDisplayWebsite.Models
{
    public class Account
    {
        [Key]
        public int Uid { get; set; }

        /// <summary>
        /// 0 - Admin
        /// 1 - NewAccount
        /// </summary>
        [Required]
        public int AccountGroup { get; set; } = 1;

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreateTime { get; set; }


        [Display(Name = "昵称")]
        [StringLength(10)]
        [Required]
        public required string NickName { get; set; }

        [Display(Name = "邮箱")]
        public string? Email { get; set; }

        [Display(Name = "密码")]
        [Required]
        public required string Password { get; set; }
    }
}