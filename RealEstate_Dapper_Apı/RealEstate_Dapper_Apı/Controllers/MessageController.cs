using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.MessageRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GetInboxLast3Message(int id)
        {
            var values = await messageRepository.GetInBoxLast3Message(id);
            return Ok(values);
        }
    }
}
