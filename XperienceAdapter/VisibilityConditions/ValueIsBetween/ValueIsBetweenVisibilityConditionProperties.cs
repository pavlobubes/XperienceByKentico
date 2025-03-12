using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceAdapter.VisibilityConditions.ValueIsBetween;

public class ValueIsBetweenVisibilityConditionProperties : VisibilityConditionWithDependencyProperties
{
    [NumberInputComponent(Label = "Min", Order = 1)]
    public int Minimum { get; set; }

    [NumberInputComponent(Label = "Max", Order = 2)]
    public int Maximum { get; set; }
}