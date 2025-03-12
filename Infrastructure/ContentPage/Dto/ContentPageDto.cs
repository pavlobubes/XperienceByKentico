using XperienceAdapter.Models;
using XperienceAdapter.Models.ReusableContentTypes.DancingGoat.Image;

namespace Infrastructure.ContentPage.Dto;

public class ContentPageDto : BasicPage, IPage
{
    public static IEnumerable<string> Columns =>
    [
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.Title),
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.Description),
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.BackgroundColor),
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.ImageThumbnail),
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.SystemFields.WebPageItemTreePath),
        nameof(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.SystemFields.WebPageItemGUID)
    ];

    public string Title { get; set; }

    public string Description { get; set; }

    public string BackgroundColor { get; set; }

    public IEnumerable<Image> ImageThumbnail { get; set; }

    public ContentPageDto(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content page) : base(page)
    {
        Title = page.Title;
        Description = page.Description;
        BackgroundColor = page.BackgroundColor;
        ImageThumbnail = page.ImageThumbnail;
    }
}