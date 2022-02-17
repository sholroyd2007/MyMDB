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

        public IEnumerable<MediaFile> MediaFiles { get; set; }

        public IEnumerable<Fact> Facts { get; set; }

        public bool Recommended { get; set; }

        public string Language { get; set; }

        public string Website { get; set; }

        public IEnumerable<AwardRecipient> AwardRecipients { get; set; }
    }
}
