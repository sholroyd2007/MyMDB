namespace MyMDB.Models
{
    public class ProductionLink : Entity
    {
        public int? MovieId { get; set; }

        public Movie Movie { get; set; }

        public int? TVShowId { get; set; }

        public TVShow TVShow { get; set; }

        public int? ProductionCompanyId { get; set; }

        public ProductionCompany ProductionCompany { get; set; }

        public int? TVNetworkId { get; set; }

        public TVNetwork TVNetwork { get; set; }
    }
}
