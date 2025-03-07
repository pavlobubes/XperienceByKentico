using Core;
using Domain.HomePage;

namespace Domain.Home;

public interface IHomeRepository : IRepository
{
    Task<HomeModel> GetHome();
}