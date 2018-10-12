using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Journal.DB.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
