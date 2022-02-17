using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class CastCrewMember : Entity
    {
        public DateTime? DOB { get; set; }

        public DateTime? Died { get; set; }

        public string From { get; set; }

        public int ProductionRoleId { get; set; }
    }
}
