using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Movies.Entity;
using System.Xml.Linq;

namespace Movies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private List<Movie> movieList;

        public MoviesController()
        {
            string jsonContent = System.IO.File.ReadAllText("./DataSources/movies.json");
            movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonContent);
        }
          
        [HttpGet("getAll")]
        public ActionResult<List<Movie>> GetAll()
        {
            return Ok(movieList);
        }

        [HttpGet("convertToXml")]
        public IActionResult ConvertToJson()
        {
            // Convert the movieList to XML
            XElement xmlMovies = new XElement("Movies",

                movieList.Select(movie => new XElement("Movie",
                    new XElement("Title", movie.Title),
                    new XElement("Year", movie.Year),
                    new XElement("Genre", movie.Genre),
                    new XElement("Director", movie.Director),
                    new XElement("Actors", movie.Actors),
                    new XElement("Rating", movie.Rating)
                ))
            );


            Response.ContentType = "application/xml";

            // Save the XML content to a file
            string directoryPath = "./DataSources";
            Directory.CreateDirectory(directoryPath);
            string filePath = Path.Combine(directoryPath, "movies.xml");
            xmlMovies.Save(filePath);

            // Return the XML content
            return Content(xmlMovies.ToString(), "application/xml");
        }


        [HttpGet("getAllSortedBy")]
        public ActionResult<List<Movie>> GetAllSortedBy([FromQuery] string sortedBy)
        {
            var sortedMovies = movieList;

            switch (sortedBy.ToLower())
            {
                case "title":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Title).ToList();
                    break;
                case "year":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Year).ToList();
                    break;
                case "genre":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Genre).ToList();
                    break;
                case "director":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Director).ToList();
                    break;
                case "actors":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Actors).ToList();
                    break;
                case "rating":
                    sortedMovies = sortedMovies.OrderBy(movie => movie.Rating).ToList();
                    break;
                default:
                    return BadRequest("Invalid sort parameter.");
            }

            return Ok(sortedMovies);
        }

        [HttpGet("search")]
        public ActionResult<List<Movie>> SearchMovies(
            [FromQuery] string title,
            [FromQuery] int? year,
            [FromQuery] string genre,
            [FromQuery] string director,
            [FromQuery] string ratingOperator,
            [FromQuery] double? ratingValue)
        {
            var filteredMovies = movieList;

            if (!string.IsNullOrEmpty(title))
            {
                filteredMovies = filteredMovies.Where(movie => movie.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            if (year.HasValue)
            {
                filteredMovies = filteredMovies.Where(movie => movie.Year == year.Value).ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                filteredMovies = filteredMovies.Where(movie => movie.Genre.ToLower().Contains(genre.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(director))
            {
                filteredMovies = filteredMovies.Where(movie => movie.Director.ToLower().Contains(director.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(ratingOperator) && ratingValue.HasValue)
            {
                switch (ratingOperator.ToLower())
                {
                    case "gt": // Greater than
                        filteredMovies = filteredMovies.Where(movie => movie.Rating > ratingValue.Value).ToList();
                        break;
                    case "lt": // Less than
                        filteredMovies = filteredMovies.Where(movie => movie.Rating < ratingValue.Value).ToList();
                        break;
                    default:
                        return BadRequest("Invalid rating operator.");
                }
            }

            return Ok(filteredMovies);
        }
    }
}


