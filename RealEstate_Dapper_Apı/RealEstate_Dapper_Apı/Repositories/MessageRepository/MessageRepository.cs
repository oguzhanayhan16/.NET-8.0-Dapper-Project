using Dapper;
using RealEstate_Dapper_API.Dtos.MessageDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<SendBoxMessageDto>> GetInBoxLast3Message(int id)
        {
            string query = "Select Top(3) MessageId,Name,Subject,Detail,SendDate,IsRead,UserImageUrl From Message Inner Join AppUser On Message.Sender=AppUser.UserId Where Receiver=@receiverId Order By MessageId Desc";

            var paramaters = new DynamicParameters();
            paramaters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<SendBoxMessageDto>(query, paramaters);
                return values.ToList();
            }
        }
    }
}
