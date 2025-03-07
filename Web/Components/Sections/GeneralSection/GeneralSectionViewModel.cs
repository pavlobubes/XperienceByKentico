using DancingGoat.Web.Components.Sections.Enums;

namespace DancingGoat.Web.Components.Sections.GeneralSection;

public class GeneralSectionViewModel
{
    public string SectionAnchor { get; set; } = string.Empty;

    public string ColorScheme { get; set; } = string.Empty;

    public string CornerStyle { get; set; } = string.Empty;

    public ColumnLayoutOption ColumnLayout { get; set; }
}