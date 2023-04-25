namespace MyMusicDbApp.Models {
    public class Album {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; } 
        public ICollection<Track> Tracks { get; set; } 
        public ICollection<Artist> Artists { get; set; } 
    }
}
