using CMS.Helpers;
using Microsoft.Extensions.Localization;

namespace XperienceAdapter.Localization;

internal class XperienceStringLocalizer : IStringLocalizer
{
    public LocalizedString this[string name] => new(name, GetString(name));

    public LocalizedString this[string name, params object[] arguments] =>
        new(name, GetString(name, arguments));

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
        Enumerable.Empty<LocalizedString>();

    private static string GetString(string key, params object[] arguments) =>
        ResHelper.GetStringFormat(key, arguments);
}