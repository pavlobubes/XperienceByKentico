using Domain.Home;
using Domain.HomePage;
using Infrastructure.HomePage.Repository;

namespace Infrastructure.Home;

public class HomeRepository(IHomePageRepository homePageRepository) : IHomeRepository
{
    public async Task<HomeModel?> GetHome()
    {
        var homePage = await homePageRepository.GetHomePage();

        if (homePage is null)
            return null;

        return new HomeModel(homePage.Title);
    }
}