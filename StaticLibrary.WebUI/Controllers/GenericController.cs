using Microsoft.AspNetCore.Mvc;
using StaticLibrary.WebUI.Services.Repository;

namespace StaticLibrary.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T>: ControllerBase
    {
        private readonly ILogger<GenericController<T>> _logger;
        private readonly IRepository<T> _repo;

        public GenericController(ILogger<GenericController<T>> logger, IRepository<T> repo)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET : /api/controller
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
    }
}
