using Kentico.Xperience.Admin.Base.Forms;
using XperienceAdapter.ValidationRules.ValueIsBetween;


[assembly: RegisterFormValidationRule(
    ValueIsBetweenValidationRule.IDENTIFIER,
    typeof(ValueIsBetweenValidationRule),
    "Entered number is between X and Y",
    "Checks that the entered number belongs to a specified closed interval."
)]

namespace XperienceAdapter.ValidationRules.ValueIsBetween;

[ValidationRuleAttribute(typeof(ValueIsBetweenValidationRuleAttribute))]
public class ValueIsBetweenValidationRule : ValidationRule<ValueIsBetweenValidationRuleProperties, ValueIsBetweenValidationRuleClientProperties, int?>
{
    internal const string IDENTIFIER = "Acme.Customizations.ValidationRules.ValueIsBetween";

    // Replace 'acme/web-admin-custom' with the name of your organization and project
    public override string ClientRuleName => "@acme/web-admin/ValueIsBetweenValidationRule";

    protected override Func<string, string> ErrorMessageFormatter => (errorMessage) => String.Format($"Min - {Properties.Min} and Max - {Properties.Max}");
    

    // Sends properties to the client for use in client-side validation
    protected override Task ConfigureClientProperties(ValueIsBetweenValidationRuleClientProperties clientProperties)
    {
        clientProperties.Min = Properties.Min;
        clientProperties.Max = Properties.Max;

        return base.ConfigureClientProperties(clientProperties);
    }

    public override Task<ValidationResult> Validate(int? value, IFormFieldValueProvider formFieldValueProvider)
    {
        if (value is null || (Convert.ToInt32(value) <= Properties.Max && Convert.ToInt32(value) >= Properties.Min))
        {
            return ValidationResult.SuccessResult();
        }

        return ValidationResult.FailResult();
    }
}