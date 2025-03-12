using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using XperienceAdapter.UIFormComponents.ColorSelector;
using XperienceAdapter.ValidationRules.ValueIsBetween;
using XperienceAdapter.VisibilityConditions.ValueIsBetween;

namespace DancingGoat.Web.Components.Widgets.TestWidget;

[FormCategory(Label = "Main", Order = 1)]
[FormCategory(Label = "Optional", Order = 3, Collapsible = true, IsCollapsed = true)]
public class TestWidgetProperties : IWidgetProperties
{
    [CheckBoxComponent(Order = 2, Label = "Show advanced")]
    public bool ShowAdvanced { get; set; } = true;

    [NumberInputComponent(Order = 4, Label = "Age", Tooltip = "Place age 30-40 for new field pop up")]
    [ValueIsBetweenValidationRule(60, 18)]
    [VisibleIfTrue(nameof(ShowAdvanced))]
    public int Age { get; set; }

    [NumberInputComponent(Order = 5, Label = "Visibility Based Property")]
    [ValueIsBetweenVisibilityCondition(nameof(Age), 40, 30)]
    public int VisibilityBasedProperty { get; set; }


    [TextInputComponent(Order = 6, Label = "City")]
    [MaxLengthValidationRule(20)]
    [VisibleIfTrue(nameof(ShowAdvanced))]
    public string City { get; set; } = string.Empty;

    [ColorSelectorComponent(Order = 7, Label = "Color")]
    public string Color { get; set; } = string.Empty;
}