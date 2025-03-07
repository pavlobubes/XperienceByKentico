using Core;
using Infrastructure.HomePage.Dto;

namespace Infrastructure.HomePage.Repository;

public interface IHomePageRepository : IRepository
{
    Task<HomePageDto?> GetHomePage();
}