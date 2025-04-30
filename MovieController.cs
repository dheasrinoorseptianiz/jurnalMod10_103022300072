using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace jurnalMod10_103022300072
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
         {
             new Movie ("The Shawshank Redemption", "Frank Darabont", new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ),
             new Movie ("The Godfather", "Francis Ford Coppola", new List<string>{"Marion Brando", "Al Pacino", "James Caan"}, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." ),
             new Movie ("The Dark Knight", "Christopher Nolan", new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham." ),
         };

        // GET api/movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(movieList);
        }

        // GET api/movie/{index}
        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Movie dengan index tersebut tidak ditemukan.");
            }
            return Ok(movieList[index]);
        }

        // POST api/movie
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Data movie tidak valid.");
            }
            movieList.Add(movie);
            return CreatedAtAction(nameof(Get), new { index = movieList.Count - 1 }, movie);
        }

        // DELETE api/movie/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Movie dengan index tersebut tidak ditemukan.");
            }
            movieList.RemoveAt(index);
            return NoContent();
        }
    }
}
