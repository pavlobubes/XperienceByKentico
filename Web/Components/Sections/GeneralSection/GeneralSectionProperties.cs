using DancingGoat.Web.Components.OptionProviders.DropdownEnum;
using DancingGoat.Web.Components.Sections.Enums;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace DancingGoat.Web.Components.Sections.GeneralSection;

public class GeneralSectionProperties : ISectionProperties
{
    [TextInputComponent(
    Label = "Section anchor",
    Order = 1)]
    public string SectionAnchor { get; set; } = string.Empty;

    [DropDownComponent(
        Label = "Color scheme",
        ExplanationText = "Select the color scheme of the section.",
        DataProviderType = typeof(DropdownEnumOptionProvider<ColorSchemeOption>),
        Order = 2)]
    public string ColorScheme { get; set; } = nameof(ColorSchemeOption.TransparentDark);

    [DropDownComponent(
        Label = "Corner type",
        ExplanationText = "Select the corner type of the section.",
        DataProviderType = typeof(DropdownEnumOptionProvider<CornerStyleOption>),
        Order = 3)]
    public string CornerStyle { get; set; } = nameof(CornerStyleOption.Round);

    [DropDownComponent(
        Label = "Column layout",
        ExplanationText = "Select the layout of the widget zones in the section.",
        DataProviderType = typeof(DropdownEnumOptionProvider<ColumnLayoutOption>),
        Order = 4)]
    public string ColumnLayout { get; set; } = nameof(ColumnLayoutOption.OneColumn);
}