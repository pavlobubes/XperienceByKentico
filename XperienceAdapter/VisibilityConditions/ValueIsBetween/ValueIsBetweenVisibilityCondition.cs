using Kentico.Xperience.Admin.Base.Forms;
using XperienceAdapter.VisibilityConditions.ValueIsBetween;

[assembly: RegisterFormVisibilityCondition(
    identifier: ValueIsBetweenVisibilityCondition.IDENTIFIER,
    conditionType: typeof(ValueIsBetweenVisibilityCondition),
    name: "Value is between",
    TargetFieldType = typeof(int)
)]

namespace XperienceAdapter.VisibilityConditions.ValueIsBetween;

[VisibilityConditionAttribute(typeof(ValueIsBetweenVisibilityConditionAttribute))]
public class ValueIsBetweenVisibilityCondition : VisibilityConditionWithDependency<ValueIsBetweenVisibilityConditionProperties>
{
    internal const string IDENTIFIER = "ValueIsBetweenVisibilityCondition";

    public override bool Evaluate(IFormFieldValueProvider formFieldValueProvider)
    {
        formFieldValueProvider.TryGet<int>(Properties.PropertyName, out var dependeeField);

        return (dependeeField >= Properties.Minimum) && (dependeeField <= Properties.Maximum);
    }
}