using Food_Journal.DB.Repositories;

namespace Food_Journal.Shared.Services
{
    public class UserService
    {
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        readonly IUserRepository _userRepository;

        public bool Login(string username, string passwordHash)
        {
            return _userRepository.LoginUser(username, passwordHash) != null;
        }
    }
}
