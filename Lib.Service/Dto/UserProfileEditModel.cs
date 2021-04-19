using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.Repository.Dto
{
    public class UserProfileEditModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Hình đại diện")]
        public byte[] Avatar { get; set; }

        [Display(Name = "Phòng ban")]
        public Guid DepartmentId { get; set; }

        [Display(Name = "Quyền")]
        public string RoleKey { get; set; }
    }
}
