using Core.Dependencies;
using Microsoft.Extensions.Localization;

namespace XperienceAdapter.Localization;

public class XperienceStringLocalizerFactory : IStringLocalizerFactory, IScoped
{
    public IStringLocalizer Create(Type resourceSource) => new XperienceStringLocalizer();

    public IStringLocalizer Create(string baseName, string location) => new XperienceStringLocalizer();
}