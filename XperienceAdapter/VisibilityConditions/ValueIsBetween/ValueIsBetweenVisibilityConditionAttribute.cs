using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceAdapter.VisibilityConditions.ValueIsBetween;

public class ValueIsBetweenVisibilityConditionAttribute : VisibilityConditionWithDependencyAttribute
{
    public int Maximum { get; set; }

    public int Minimum { get; set; }

    public ValueIsBetweenVisibilityConditionAttribute(string propertyName,
             int max, int min) : base(propertyName)
    {
        Maximum = max;
        Minimum = min;
    }
}