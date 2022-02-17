using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Episode : Entity
    {
        public DateTime AirDate { get; set; }

        public IEnumerable<CastCrewMember> CastCrewMembers { get; set; }

        public int Length { get; set; }
    }
}
