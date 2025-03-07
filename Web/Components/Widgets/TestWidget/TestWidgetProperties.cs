using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using XperienceAdapter.ValidationRules.ValueIsBetween;

namespace DancingGoat.Web.Components.Widgets.TestWidget;

[FormCategory(Label = "Main", Order = 1)]
[FormCategory(Label = "Optional", Order = 3, Collapsible = true, IsCollapsed = true)]
public class TestWidgetProperties : IWidgetProperties
{
    [CheckBoxComponent(Order = 2, Label = "Show advanced")]
    public bool ShowAdvanced { get; set; } = true;

    [NumberInputComponent(Order = 4, Label = "Age")]
    [ValueIsBetweenValidationRule(60, 18)]
    [VisibleIfTrue(nameof(ShowAdvanced))]
    public int Age { get; set; }

    [TextInputComponent(Order = 5, Label = "City")]
    [MaxLengthValidationRule(20)]
    [VisibleIfTrue(nameof(ShowAdvanced))]
    public string City { get; set; } = string.Empty;
}