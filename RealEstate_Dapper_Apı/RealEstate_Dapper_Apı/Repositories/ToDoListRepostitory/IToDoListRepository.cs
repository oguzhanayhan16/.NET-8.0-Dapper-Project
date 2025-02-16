using RealEstate_Dapper_API.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_API.Repositories.ToDoListRepostitory
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task CreateToDoList(CreateToDoListDto ToDoListDto);
        Task DeleteToDoList(int id);

        Task UpdateToDoList(UpdateToDoListDto ToDoListDto);

        Task<GetByIDToDoListDto> GetToDoList(int id);
    }
}
