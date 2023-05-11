using JWT_test.Dto.User;

namespace JWT_test.Services.Interface
{
    public interface IUser
    {
        void Create(CreateUserDto input);
        string Login(LoginDto input);
    }
}
