using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JWT_test.Exceptions
{
    public class UserFriendlyException:Exception
    {
        public UserFriendlyException(string message) :base(message){ }
    }
}
