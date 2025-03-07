using CMS.Websites;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Home;

namespace XperienceAdapter.Models;

public class BasicPage
{
    internal static IEnumerable<string> SourceColumns => new List<string>
    {
        nameof(Home.SystemFields.ContentItemID)
    };

    public int ContentItemID { get; }

    protected BasicPage(IWebPageFieldsSource page)
    {
        ContentItemID = page.SystemFields.ContentItemID;
    }
}