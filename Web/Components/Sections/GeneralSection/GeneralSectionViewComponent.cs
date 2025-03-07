using DancingGoat.Web.Components.Sections.Enums;
using DancingGoat.Web.Components.Sections.GeneralSection;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;

[assembly: RegisterSection(
    identifier: GeneralSectionViewComponent.IDENTIFIER,
    viewComponentType: typeof(GeneralSectionViewComponent),
    name: "General section",
    propertiesType: typeof(GeneralSectionProperties),
    Description = "Highly customizable general section.",
    IconClass = "icon-square")]

namespace DancingGoat.Web.Components.Sections.GeneralSection;

public class GeneralSectionViewComponent : ViewComponent
{
    public const string IDENTIFIER = "DancingGoat.GeneralSection";

    public IViewComponentResult Invoke(ComponentViewModel<GeneralSectionProperties> sectionProperties)
    {
        var properties = sectionProperties.Properties;

        if (!Enum.TryParse(properties.ColumnLayout, out ColumnLayoutOption columnLayout))
        {
            columnLayout = ColumnLayoutOption.OneColumn;
        }

        var model = new GeneralSectionViewModel()
        {
            SectionAnchor = properties.SectionAnchor,
            ColumnLayout = columnLayout,
            ColorScheme = properties.ColorScheme,
            CornerStyle = properties.CornerStyle,
        };

        return View("~/Views/Shared/Components/GeneralSection/Default.cshtml", model);
    }
}