using Application.Content.Queries.GetContentQuery;
using DancingGoat.Web.Constants;
using DancingGoat.Web.Controllers;
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

public class ContentController(IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        var contentModel = await mediator.Send(new GetContentQuery());

        if (contentModel is null) return NotFound();

        return View(contentModel);
    }
}