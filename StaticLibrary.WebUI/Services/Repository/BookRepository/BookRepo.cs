using StaticLibrary.WebUI.Models;
using StaticLibrary.WebUI.Services.Repository.Database;
using System.Linq;

namespace StaticLibrary.WebUI.Services.Repository.BookRepository
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(ApplicationDbContext dbContext)
        {

        }
    }
}
