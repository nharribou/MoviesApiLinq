namespace Movies.Entity
{
public class TvShow
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public List<string> Actors { get; set; }
    public string Plot { get; set; }
    public double Rating { get; set; }
    public string Image { get; set; }
}



}
