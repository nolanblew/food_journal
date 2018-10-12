using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Food_Journal.DB.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Entry> JournalEntries { get; set; }

        public DateTimeOffset LastLoggedIn { get; set; }
    }
}
