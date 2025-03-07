using Kentico.PageBuilder.Web.Mvc;

namespace DancingGoat.Web.Components.ViewComponents.PageBuilderColumns;

public class PageBuilderColumnViewModel
{
    public string CssClass { get; set; } = string.Empty;

    public string Identifier { get; set; } = string.Empty;

    public EditableAreaOptions? EditableAreaOptions { get; set; }
}