using RealEstate_Dapper_API.Repositories.AppUserRepository;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;
using RealEstate_Dapper_API.Repositories.CategoryRepository;
using RealEstate_Dapper_API.Repositories.ContactRepository;
using RealEstate_Dapper_API.Repositories.EmployeeRepository;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.ChartRespository;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.LastProcutsRepository;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;
using RealEstate_Dapper_API.Repositories.MessageRepository;
using RealEstate_Dapper_API.Repositories.PopularLocationRepository;
using RealEstate_Dapper_API.Repositories.ProductImageRepository;
using RealEstate_Dapper_API.Repositories.ProductRepository;
using RealEstate_Dapper_API.Repositories.PropertyAmenityRepository;
using RealEstate_Dapper_API.Repositories.ServiceRepository;
using RealEstate_Dapper_API.Repositories.StatistikRepostiory;
using RealEstate_Dapper_API.Repositories.SubFeatureRepository;
using RealEstate_Dapper_API.Repositories.TestimonialRepository;
using RealEstate_Dapper_API.Repositories.ToDoListRepostitory;
using RealEstate_Dapper_API.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_API.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreRepostiyory, WhoWeAreRepository>();
           services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TesminoalRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatistikRepository, StatistikRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILastProductRepository, LastProductRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
           services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
