using CMS.Core;
using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceAdapter.ValidationRules.ValueIsBetween;

public class ValueIsBetweenValidationRuleProperties : ValidationRuleProperties
{
    [NumberInputComponent(Label = "Minimum")]
    public int Min { get; set; }

    [NumberInputComponent(Label = "Maximum")]
    public int Max { get; set; }

    // Overriding the 'ErrorMessage' property and not assigning an editing component hides it from the configuration dialog.
    // This is desirable since the rule returns an error message via the 'Validate' method --
    // anything entered under 'ErrorMessage' has lower priority and is ignored by the system.
    public override string ErrorMessage { get => base.ErrorMessage; set => base.ErrorMessage = value; }

    public override string GetDescriptionText(ILocalizationService localizationService) => $"Entered value is between Minimum and Maximum.";
}