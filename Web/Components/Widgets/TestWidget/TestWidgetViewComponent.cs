using DancingGoat.Web.Components.Widgets.TestWidget;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    TestWidgetViewComponent.IDENTIFIER,
    typeof(TestWidgetViewComponent),
    "Test",
    typeof(TestWidgetProperties),
    Description = "Widget just fo test.",
    IconClass = "icon-rectangle-paragraph"
)]

namespace DancingGoat.Web.Components.Widgets.TestWidget;

public class TestWidgetViewComponent : ViewComponent
{
    public const string IDENTIFIER = "Shared.TestWidget";

    public async Task<ViewViewComponentResult> InvokeAsync(TestWidgetProperties properties)
    {
        await Task.Delay(1);
        var test = Validator.TryValidateObject(properties, new(properties), [], true);
        return View(new TestWidgetViewModel());
    }
}