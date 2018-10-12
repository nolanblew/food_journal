using Food_Journal.DB.Models;
using System.Linq;

namespace Food_Journal.DB.Repositories
{
    public interface IUserRepository
    {
        User LoginUser(string username, string passwordHash);
        User Create(User user);
    }

    public class UserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        readonly ApplicationContext _context;

        public User LoginUser(string username, string passwordHash)
        {
            return _context.Users.FirstOrDefault(
                u => u.Username == username
                     && u.Password == passwordHash);
        }

        public User Create(User user)
        {
            var trackedUser = _context.Users.Add(user);
            return trackedUser.Entity;
        }
    }
}
