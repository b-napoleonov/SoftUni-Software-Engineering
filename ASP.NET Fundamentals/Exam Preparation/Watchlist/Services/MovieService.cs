using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToWatchedAsync(int movieId, string userId)
        {
            var entity = context.UsersMovies.FirstOrDefault(x => x.UserId == userId && movieId == x.MovieId);

            if (entity == null)
            {
                var userMovie = new UserMovie
                {
                    UserId = userId,
                    MovieId = movieId,
                };

                await context.UsersMovies.AddAsync(userMovie);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<AllMovieViewModel>> GetAllMoviesAsync()
        {
            return await context.Movies
                .Select(m => new AllMovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllMovieViewModel>> GetUserWatchedMoviesAsync(string userId)
        {
            return await context.UsersMovies
                .Where(um => um.UserId == userId)
                .Select(m => new AllMovieViewModel
                {
                    Id = m.Movie.Id,
                    Title = m.Movie.Title,
                    Director = m.Movie.Director,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating,
                    Genre = m.Movie.Genre.Name
                })
                .ToListAsync();
        }

        public async Task RemoveMovieFromWatchedAsync(int movieId, string userId)
        {
            var userMovie = await context.UsersMovies
                .FirstOrDefaultAsync(um => um.MovieId == movieId && um.UserId == userId);

            if (userMovie != null)
            {
                context.UsersMovies.Remove(userMovie);
                await context.SaveChangesAsync();
            }
        }
    }
}
