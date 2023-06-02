using System.Collections.Generic;
using Movies.Entity;

namespace Movies.Datasources
{
    public static class TvShowList
    {
        public static List<TvShow> GetTvShows()
        {
            return new List<TvShow>
            {
                new TvShow
                {
                    Title = "Breaking Bad",
                    Year = 2008,
                    Genre = "Crime, Drama, Thriller",
                    Director = "Vince Gilligan",
                    Actors = new List<string> { "Bryan Cranston", "Aaron Paul", "Anna Gunn" },
                    Plot = "A high school chemistry teacher turned methamphetamine manufacturer partners with a former student to secure his family's financial future as he battles terminal lung cancer.",
                    Rating = 9.5,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "Game of Thrones",
                    Year = 2011,
                    Genre = "Action, Adventure, Drama",
                    Director = "David Benioff, D.B. Weiss",
                    Actors = new List<string> { "Emilia Clarke", "Kit Harington", "Peter Dinklage" },
                    Plot = "Nine noble families fight for control over the mythical lands of Westeros, while an ancient enemy returns after being dormant for thousands of years.",
                    Rating = 9.3,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "Friends",
                    Year = 1994,
                    Genre = "Comedy, Romance",
                    Director = "David Crane, Marta Kauffman",
                    Actors = new List<string> { "Jennifer Aniston", "Courteney Cox", "Lisa Kudrow" },
                    Plot = "Follows the personal and professional lives of six twenty to thirty-something friends living in Manhattan.",
                    Rating = 8.9,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "Stranger Things",
                    Year = 2016,
                    Genre = "Drama, Fantasy, Horror",
                    Director = "Matt Duffer, Ross Duffer",
                    Actors = new List<string> { "Millie Bobby Brown", "Finn Wolfhard", "Winona Ryder" },
                    Plot = "When a young boy goes missing in a small town, a group of kids uncover a series of supernatural mysteries and government conspiracies.",
                    Rating = 8.8,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "The Office",
                    Year = 2005,
                    Genre = "Comedy",
                    Director = "Greg Daniels",
                    Actors = new List<string> { "Steve Carell", "Rainn Wilson", "John Krasinski" },
                    Plot = "A mockumentary on a group of typical office workers, where the workday consists of ego clashes, inappropriate behavior, and tedium.",
                    Rating = 8.9,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "The Simpsons",
                    Year = 1989,
                    Genre = "Animation, Comedy",
                    Director = "James L. Brooks, Matt Groening, Sam Simon",
                    Actors = new List<string> { "Dan Castellaneta", "Nancy Cartwright", "Harry Shearer" },
                    Plot = "The satiric adventures of a working-class family in the misfit city of Springfield.",
                    Rating = 8.7,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "Sherlock",
                    Year = 2010,
                    Genre = "Crime, Drama, Mystery",
                    Director = "Mark Gatiss, Steven Moffat",
                    Actors = new List<string> { "Benedict Cumberbatch", "Martin Freeman", "Una Stubbs" },
                    Plot = "A modern update finds the famous sleuth and his doctor partner solving crime in 21st century London.",
                    Rating = 9.1,
                    Image = "image_link"
                },
                new TvShow
                {
                    Title = "The Crown",
                    Year = 2016,
                    Genre = "Biography, Drama, History",
                    Director = "Peter Morgan",
                    Actors = new List<string> { "Claire Foy", "Matt Smith", "Olivia Colman" },
                    Plot = "Follows the political rivalries and romance of Queen Elizabeth II's reign and the events that shaped the second half of the twentieth century.",
                    Rating = 8.7,
                    Image = "image_link"
                }
            };
        }
    }
}
