using System.Security.Claims;
using TestTask.Domain;
using TestTask.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly testsDBContext _context;
        public UserService(testsDBContext context)
        {
            _context = context;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.IdUser.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
