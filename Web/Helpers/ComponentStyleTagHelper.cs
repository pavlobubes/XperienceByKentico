using DancingGoat.Web.Services;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace DancingGoat.Web.Helpers;

[HtmlTargetElement("tg-component-style")]
public class ComponentStyleTagHelper(IComponentStyleEnumService componentStyleEnumService) : TagHelper
{
    private const string DIV_TAG = "div";

    public string ColorScheme { get; set; } = string.Empty;

    public string CornerStyle { get; set; } = string.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = DIV_TAG;

        List<string> cssClasses = [];

        var colorScheme = componentStyleEnumService.GetColorScheme(ColorScheme);
        cssClasses.AddRange(componentStyleEnumService.GetColorSchemeClasses(colorScheme));

        var cornerStyle = componentStyleEnumService.GetCornerStyle(CornerStyle);
        cssClasses.AddRange(componentStyleEnumService.GetCornerStyleClasses(cornerStyle));

        if (cssClasses.Count > 0)
        {
            foreach (string cssClass in cssClasses)
            {
                output.AddClass(cssClass, HtmlEncoder.Default);
            }
        }
    }
}