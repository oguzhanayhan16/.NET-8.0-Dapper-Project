namespace RealEstate_Dapper_API.Repositories.StatistikRepostiory
{
    public interface IStatistikRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProduction();
        string CategoryNameByMaxProduction();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();

        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AvaregeRoomCount();
        int ActiveEmployeeCount();

    }
}
