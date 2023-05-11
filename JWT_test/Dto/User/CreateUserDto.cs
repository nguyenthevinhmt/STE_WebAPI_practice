using JWT_test.Constants;
using JWT_test.Utils;
using System.ComponentModel.DataAnnotations;

namespace JWT_test.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(30, ErrorMessage = "Tên tài khoản dài từ 3 đến 30 ký tự", MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Mật khẩu dài từ 3 đến 30 ký tự", MinimumLength = 3)]
        public string Password { get; set; }
        [IntegerRange(AllowableValues = new int[] { UserTypes.Admin, UserTypes.Customer })]
        public int UserType { get; set; }
    }
}
