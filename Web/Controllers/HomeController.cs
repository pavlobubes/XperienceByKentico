using Application.Home.Queries.GetHomeQuery;
using DancingGoat.Web.Constants;
using DancingGoat.Web.Controllers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Home;


[assembly: RegisterWebPageRoute(
    Home.CONTENT_TYPE_NAME,
    typeof(HomeController),
    WebsiteChannelNames = [WebsiteConstants.DANCINGWEBSITE_CHANNEL_NAME, WebsiteConstants.PEREHINSKEWEBSITE_CHANNEL_NAME]
)]

namespace DancingGoat.Web.Controllers;

public class HomeController(
    IWebPageDataContextRetriever webPageDataContextRetriever,
    IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        var webPage = webPageDataContextRetriever.Retrieve().WebPage;

        if (webPage is null) return NotFound();

        var homeModel = await mediator.Send(new GetHomeQuery(webPage.WebPageItemID, webPage.LanguageName));
        return View(homeModel);
    }
}