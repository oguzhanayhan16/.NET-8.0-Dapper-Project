﻿namespace RealEstate_Dapper_UI.Dtos.MessageDtos
{
    public class SendBoxMessageDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string UserImageUrl { get; set; }
    }
}
