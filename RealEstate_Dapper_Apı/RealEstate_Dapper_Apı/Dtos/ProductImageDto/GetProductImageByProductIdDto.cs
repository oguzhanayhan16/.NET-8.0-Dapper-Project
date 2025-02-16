namespace RealEstate_Dapper_API.Dtos.ProductImageDto
{
    public class GetProductImageByProductIdDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
