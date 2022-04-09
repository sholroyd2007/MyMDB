using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Edited { get; set; }

        public bool Deleted { get; set; } 
    }
}
