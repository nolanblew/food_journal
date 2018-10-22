using Food_Journal.DB.Models;

namespace Food_Journal.Api.Helpers
{
    public static class Extensions
    {
        public static UserPartial ToPartial(this User user)
        {
            return new UserPartial
            {
                CreatedAt = user.CreatedAt,
                Id = user.Id,
                JournalEntries = user.JournalEntries,
                LastLoggedIn = user.LastLoggedIn,
                Name = user.Name,
                UpdatedAt = user.UpdatedAt,
                Username = user.Username,
            };
        }
    }
}
