﻿namespace RealEstate_Dapper_UI.Dtos.ProductDetailDtos
{
    public class GetProudctDetailByIdDto
    {
        public int ProductDetailId { get; set; }
        public int BedRoomCount { get; set; }
        public int ProductSize { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public int GarageSize { get; set; }
        public string BuidlYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public int ProductId { get; set; }
      

    }
}
