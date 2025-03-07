using Core;
using DancingGoat.Web.Components.Sections.Enums;
using System.Collections.Generic;

namespace DancingGoat.Web.Services;

public interface IComponentStyleEnumService : IService
{
    IEnumerable<string> GetColorSchemeClasses(ColorSchemeOption colorScheme);

    IEnumerable<string> GetCornerStyleClasses(CornerStyleOption cornerStyle);

    CornerStyleOption GetCornerStyle(string cornerStyleString);

    ColorSchemeOption GetColorScheme(string colorSchemeString);

    ColorSchemeOption GetLinkStyle(string linkStyleString);
}