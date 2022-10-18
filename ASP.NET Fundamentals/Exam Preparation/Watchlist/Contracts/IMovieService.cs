using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMovieViewModel>> GetAllMoviesAsync();

        Task<IEnumerable<Genre>> GetAllGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task<IEnumerable<AllMovieViewModel>> GetUserWatchedMoviesAsync(string userId);

        Task AddMovieToWatchedAsync(int movieId, string userId);

        Task RemoveMovieFromWatchedAsync(int movieId, string userId);
    }
}
 