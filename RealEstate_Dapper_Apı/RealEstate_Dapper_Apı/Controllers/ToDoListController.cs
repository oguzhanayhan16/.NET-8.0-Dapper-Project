using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.CategoryRepository;
using RealEstate_Dapper_API.Repositories.ToDoListRepostitory;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository ;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }
    }
}
