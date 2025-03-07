using Infrastructure.HomePage.Dto;
using XperienceAdapter.Repositories.Implementations;

namespace Infrastructure.HomePage.Repository;

public class HomePageRepository : BasePageContentRepository<HomePageDto, XperienceAdapter.Models.PageContentTypes.DancingGoat.Home.Home>, IHomePageRepository
{
    public async Task<HomePageDto?> GetHomePage() =>
        await GetPageAsync(XperienceAdapter.Models.PageContentTypes.DancingGoat.Home.Home.CONTENT_TYPE_NAME);

    protected override HomePageDto MapProperties(XperienceAdapter.Models.PageContentTypes.DancingGoat.Home.Home page) => new(page);
}