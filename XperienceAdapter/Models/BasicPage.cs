using CMS.Websites;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Home;

namespace XperienceAdapter.Models;

public class BasicPage
{
    internal static IEnumerable<string> SourceColumns => new List<string>
    {
        nameof(Home.SystemFields.ContentItemID),
        nameof(Home.SystemFields.WebPageItemTreePath),
        nameof(Home.SystemFields.WebPageItemGUID),
        nameof(Home.SystemFields.WebPageItemID)
    };

    public int ContentItemID { get; }

    public string WebPageItemTreePath { get; set; }

    public Guid WebPageItemGUID { get; set; }

    public int WebPageItemID { get; set; }

    protected BasicPage(IWebPageFieldsSource page)
    {
        ContentItemID = page.SystemFields.ContentItemID;
        WebPageItemTreePath = page.SystemFields.WebPageItemTreePath;
        WebPageItemGUID = page.SystemFields.WebPageItemGUID;
        WebPageItemID = page.SystemFields.WebPageItemID;
    }
}