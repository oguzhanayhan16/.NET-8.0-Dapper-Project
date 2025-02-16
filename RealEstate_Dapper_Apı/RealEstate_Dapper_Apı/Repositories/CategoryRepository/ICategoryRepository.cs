using RealEstate_Dapper_API.Dtos.CategoryDtos;

namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategory (CreateCategoryDto categoryDto);
        Task DeleteCategory (int id);

        Task UpdateCategory (UpdateCategoryDto categoryDto);

        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}
