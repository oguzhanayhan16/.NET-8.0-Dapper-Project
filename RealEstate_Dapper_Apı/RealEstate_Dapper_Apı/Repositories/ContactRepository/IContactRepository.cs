using RealEstate_Dapper_API.Dtos.ContactDtos;

namespace RealEstate_Dapper_API.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactResultDto>> GetLast4ContactAsync();
        Task CreateContact(CreateContactDto ContactDto);
        Task DeleteContact(int id);


        Task<GetByIDContactDto> GetContact(int id);
    }
}
