using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UsersMovies = new List<UserMovie>();
        }

        public IEnumerable<UserMovie> UsersMovies { get; set; }
    }
}
