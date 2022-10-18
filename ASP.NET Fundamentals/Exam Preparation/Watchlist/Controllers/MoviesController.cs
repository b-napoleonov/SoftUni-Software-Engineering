using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await movieService.GetAllMoviesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel()
            {
                Genres = await movieService.GetAllGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await movieService.AddMovieAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");

                return View(model);                
            }
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var model = await movieService.GetUserWatchedMoviesAsync(GetCurrentUserId());

            return View("Mine", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            await movieService.AddMovieToWatchedAsync(movieId, GetCurrentUserId());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            await movieService.RemoveMovieFromWatchedAsync(movieId, GetCurrentUserId());

            return RedirectToAction(nameof(Watched));
        }
    }
}
