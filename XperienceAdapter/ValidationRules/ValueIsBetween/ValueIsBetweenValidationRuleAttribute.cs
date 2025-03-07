using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceAdapter.ValidationRules.ValueIsBetween;

public class ValueIsBetweenValidationRuleAttribute : ValidationRuleAttribute
{
    public int Max
    {
        get;
    }

    public int Min
    {
        get;
    }

    public ValueIsBetweenValidationRuleAttribute(int max, int min)
    {
        Max = max;
        Min = min;
    }
}