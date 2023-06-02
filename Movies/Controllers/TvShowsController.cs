using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Movies.Datasources;
using Movies.Entity;

namespace Movies.Controllers
{
    [ApiController]
    [Route("api/tvshows")]
    public class TvShowsController : ControllerBase
    {
        private List<TvShow> tvShowList;

        public TvShowsController()
        {
            tvShowList = TvShowList.GetTvShows();
        }

        [HttpGet("getAll")]
        public ActionResult<List<TvShow>> GetAll()
        {
            return Ok(tvShowList);
        }

        [HttpGet("getAllSortedBy")]
        public ActionResult<List<TvShow>> GetAllSortedBy([FromQuery] string sortedBy)
        {
            var sortedTvShows = tvShowList;

            switch (sortedBy.ToLower())
            {
                case "title":
                    sortedTvShows = sortedTvShows.OrderBy(tvShow => tvShow.Title).ToList();
                    break;
                case "year":
                    sortedTvShows = sortedTvShows.OrderBy(tvShow => tvShow.Year).ToList();
                    break;
                case "genre":
                    sortedTvShows = sortedTvShows.OrderBy(tvShow => tvShow.Genre).ToList();
                    break;
                case "director":
                    sortedTvShows = sortedTvShows.OrderBy(tvShow => tvShow.Director).ToList();
                    break;
                case "actors":
                    sortedTvShows = sortedTvShows.OrderBy(tvShow => tvShow.Actors.First()).ToList();
                    break;
                case "rating":
                    sortedTvShows = sortedTvShows.OrderByDescending(tvShow => tvShow.Rating).ToList();
                    break;
                default:
                    return BadRequest("Invalid sort parameter.");
            }

            return Ok(sortedTvShows);
        }

        [HttpGet("search")]
        public ActionResult<List<TvShow>> SearchTvShows(
            [FromQuery] string? title,
            [FromQuery] int? year,
            [FromQuery] string? genre,
            [FromQuery] string? director,
            [FromQuery] string? actors,
            [FromQuery] string? ratingOperator,
            [FromQuery] double? ratingValue)
        {
            var filteredTvShows = tvShowList;

            // Apply filters based on the provided query parameters
            if (!string.IsNullOrEmpty(title))
            {
                filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            if (year.HasValue)
            {
                filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Year == year.Value).ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Genre.ToLower().Contains(genre.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(director))
            {
                filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Director.ToLower().Contains(director.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(actors))
            {
                filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Actors.Any(actor => actor.ToLower().Contains(actors.ToLower()))).ToList();
            }

            if (!string.IsNullOrEmpty(ratingOperator) && ratingValue.HasValue)
            {
                switch (ratingOperator.ToLower())
                {
                    case ">": // Greater than
                        filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Rating > ratingValue.Value).ToList();
                        break;
                    case "<": // Less than
                        filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Rating < ratingValue.Value).ToList();
                        break;
                    case "=": // Equal to
                        filteredTvShows = filteredTvShows.Where(tvShow => tvShow.Rating == ratingValue.Value).ToList();
                        break;
                    default:
                        return BadRequest("Invalid rating operator.");
                }
            }

            // Check if any filters were applied
            if (string.IsNullOrEmpty(title) && !year.HasValue && string.IsNullOrEmpty(genre) && string.IsNullOrEmpty(director) &&
                string.IsNullOrEmpty(actors) && (string.IsNullOrEmpty(ratingOperator) || !ratingValue.HasValue))
            {
                return BadRequest("At least one search parameter is required.");
            }

            return Ok(filteredTvShows);
        }
    }
}
