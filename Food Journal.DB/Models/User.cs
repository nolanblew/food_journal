using System;
using System.Collections.Generic;

namespace Food_Journal.DB.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Entry> JournalEntries { get; set; }

        public DateTimeOffset LastLoggedIn { get; set; }
    }
}
