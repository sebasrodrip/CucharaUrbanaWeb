using Frontend.Models;
using NuGet.Common;

namespace Frontend.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginModel GetUser(UserViewModel user);
        TokenModel Login(UserViewModel user);

    }
}
