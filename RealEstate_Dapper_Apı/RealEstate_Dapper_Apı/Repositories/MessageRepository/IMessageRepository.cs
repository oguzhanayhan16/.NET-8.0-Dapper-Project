using RealEstate_Dapper_API.Dtos.MessageDtos;

namespace RealEstate_Dapper_API.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        Task<List<SendBoxMessageDto>> GetInBoxLast3Message(int id);
    }
}
