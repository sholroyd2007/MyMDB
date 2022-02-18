using System;

namespace MyMDB.Models
{
    public class FactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }
    }
}
