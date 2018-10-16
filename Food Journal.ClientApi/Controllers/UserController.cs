using Food_Journal.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food_Journal.ClientApi.Controllers
{
    public interface IUserController
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetUsers();
        Task<User> ShowUser(int id);
        Task<User> UpdateUser(int id, User user);
    }

    public class UserController : BaseController<User>, IUserController
    {
        protected override string ControllerEndpoint => "users";

        public Task<List<User>> GetUsers()
        {
            return _ListAsync();
        }

        public Task<User> ShowUser(int id)
        {
            return _ShowAsync(id);
        }

        public Task<User> CreateUser(User user)
        {
            return _CreateAsync(user);
        }

        public Task<User> UpdateUser(int id, User user)
        {
            return _UpdateAsync(id, user);
        }
    }
}
