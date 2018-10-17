using Food_Journal.DB.Models;

namespace Food_Journal.Shared.Services
{
    public interface IApplicationState
    {
        User CurrentUser { get; set; }
    }

    public class ApplicationState : IApplicationState
    {
        public User CurrentUser { get; set; }
    }
}
