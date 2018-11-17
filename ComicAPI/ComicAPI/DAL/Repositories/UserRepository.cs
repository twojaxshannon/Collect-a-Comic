using ComicAPI.DAL.Abstract;
using ComicAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ComicAPI.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository()
        {

        }

        /// <summary>
        /// Fetch the User with the given name.
        /// </summary>
        /// <param name="userName">Name to search by</param>
        /// <returns>User object matching the username, or an empty User object if there is no match</returns>
        public User GetUserByName(string userName)
        {
            // In-depth authentication skipped for demo project. First to claim the username wins!
            return mongoCollection.Find(x => x.Name == userName).FirstOrDefault();
        }
    }
}
