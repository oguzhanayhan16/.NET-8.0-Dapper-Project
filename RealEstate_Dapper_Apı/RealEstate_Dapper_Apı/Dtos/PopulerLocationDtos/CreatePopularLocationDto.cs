namespace RealEstate_Dapper_API.Dtos.PopulerLocationDtos
{
    public class CreatePopularLocationDto
    {
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}
