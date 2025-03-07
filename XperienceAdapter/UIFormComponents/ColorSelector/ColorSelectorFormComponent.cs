using Kentico.Xperience.Admin.Base.Forms;
using XperienceAdapter.UIFormComponents.ColorSelector;

[assembly: RegisterFormComponent("Acme.UIFormComponents.ColorSelector",
    typeof(ColorSelectorFormComponent),
    "Color selector")]

namespace XperienceAdapter.UIFormComponents.ColorSelector;

[ComponentAttribute(typeof(ColorSelectorComponentAttribute))]
public class ColorSelectorFormComponent : FormComponent<ColorSelectorFormComponentClientProperties, string>
{
    public override string ClientComponentName => "@acme/web-admin/ColorSelector";

    protected override Task ConfigureClientProperties(ColorSelectorFormComponentClientProperties clientProperties)
    {
        base.ConfigureClientProperties(clientProperties);

        clientProperties.Value = string.IsNullOrEmpty(clientProperties.Value) ? "#FFFFFF" : clientProperties.Value;

        return Task.CompletedTask;
    }
}

public class ColorSelectorFormComponentClientProperties : FormComponentClientProperties<string>
{
}