using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceAdapter.ValidationRules.ValueIsBetween;

public class ValueIsBetweenValidationRuleClientProperties : ValidationRuleClientProperties
{
    public int Min { get; set; }

    public int Max { get; set; }
}