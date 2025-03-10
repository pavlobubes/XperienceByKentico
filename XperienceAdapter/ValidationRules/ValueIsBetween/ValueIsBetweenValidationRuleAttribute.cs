using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceAdapter.ValidationRules.ValueIsBetween;

public class ValueIsBetweenValidationRuleAttribute(int max, int min) : ValidationRuleAttribute
{
    public int Max { get; } = max;

    public int Min { get; } = min;
}
