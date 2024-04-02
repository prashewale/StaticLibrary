using StaticLibrary.WebUI.Models;
using StaticLibrary.WebUI.Services.Repository.Database;

namespace StaticLibrary.WebUI.Services.Repository.AuthorRepository
{
    public class AuthorRepo : BaseRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(ApplicationDbContext dbContext)
        {
        }

    }
}
