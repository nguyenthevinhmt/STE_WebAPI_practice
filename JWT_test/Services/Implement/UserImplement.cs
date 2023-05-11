using JWT_test.Constants;
using JWT_test.Context;
using JWT_test.Dto.User;
using JWT_test.Exceptions;
using JWT_test.Models;
using JWT_test.Services.Interface;
using JWT_test.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace JWT_test.Services.Implement
{
    public class UserImplement : IUser
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserImplement(AppDbContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }
        public void Create(CreateUserDto input)
        {
            if (_context.Users.Any(u => u.UserName == input.Username))
            {
                throw new UserFriendlyException($"Tên tài khoản \"{input.Username}\" đã tồn tại");
            }
            _context.Users.Add(new User
            {
                UserName = input.Username,
                Password = CommonUtils.CreateMD5(input.Password),
                UserType = input.UserType
            });
            _context.SaveChanges();
        }

        public string Login(LoginDto input)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == input.Username);
            if (user == null)
            {
                throw new UserFriendlyException($"Tài khoản \"{input.Username}\" không tồn tại");
            }

            if (CommonUtils.CreateMD5(input.Password) == user.Password)
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(CustomClaimTypes.UserType, user.UserType.ToString())
                };
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(_configuration.GetValue<int>("JWT:Expires")),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                throw new UserFriendlyException($"Mật khẩu không chính xác");
            }
        }
    }
}
