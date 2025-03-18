using Application.Content.Queries.GetContentQuery;
using DancingGoat.Web.Constants;
using DancingGoat.Web.Controllers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Content;

[assembly: RegisterWebPageRoute(
    Content.CONTENT_TYPE_NAME,
    typeof(ContentController),
    WebsiteChannelNames = [WebsiteConstants.DANCINGWEBSITE_CHANNEL_NAME, WebsiteConstants.PEREHINSKEWEBSITE_CHANNEL_NAME]
)]

namespace DancingGoat.Web.Controllers;

public class ContentController(
    IWebPageDataContextRetriever webPageDataContextRetriever,
    IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        var webPage = webPageDataContextRetriever.Retrieve().WebPage;

        var contentModel = await mediator.Send(new GetContentQuery(webPage.WebPageItemID, webPage.LanguageName, webPage.WebsiteChannelName));

        if (contentModel is null) return NotFound();

        // Regular
        return View(contentModel);

        // Template test
        //return new TemplateResult(contentModel);
    }
}