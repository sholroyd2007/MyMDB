namespace MyMDB.Models
{
    public class Featured : Entity
    {
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public int? TVShowId { get; set; }
        public TVShow TVShow { get; set; }
        public bool Banner { get; set; }
        public bool Recommended { get; set; }
        public bool EditorPick { get; set; }
    }
}
