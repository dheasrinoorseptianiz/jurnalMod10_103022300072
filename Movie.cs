namespace jurnalMod10_103022300072
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public  List<string> Stars { get; set; }
        public string Description { get; set; }

        public Movie(string title, string director, List<string> stars, string description)
        {
            this.Title = title;
            this.Director = director;
            this.Stars = stars;
            this.Description = description;
        }
    }


}
