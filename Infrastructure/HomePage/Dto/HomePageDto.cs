using XperienceAdapter.Models;

namespace Infrastructure.HomePage.Dto;

public class HomePageDto : BasicPage, IPage
{
    public static IEnumerable<string> Columns =>
    [
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Home.Home.Title)
    ];

    public string Title { get; set; }

    public HomePageDto(XperienceAdapter.Models.PageContentTypes.DancingGoat.Home.Home page) : base(page)
    {
        Title = page.Title;
    }
}