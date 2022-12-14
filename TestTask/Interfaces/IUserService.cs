using System.Security.Claims;

namespace TestTask.Interfaces
{
    public interface IUserService
    {
        ClaimsIdentity GetIdentity(string username, string password);
    }
}
