using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Journal.DB.Models;

namespace Food_Journal.ClientApi.Controllers
{
    public interface IEntriesController
    {
        Task<List<Entry>> GetAllEntries(User user);
    }

    public class EntriesController : BaseController<Entry>, IEntriesController
    {
        public async Task<List<Entry>> GetAllEntries(User user)
        {
            var allEntries = await _ListAsync();
            return allEntries.Where(e => e.User.Id == user.Id).ToList();
        }
    }
}
