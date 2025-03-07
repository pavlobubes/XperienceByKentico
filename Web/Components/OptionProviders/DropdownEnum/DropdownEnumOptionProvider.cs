using EnumsNET;
using System.ComponentModel;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace DancingGoat.Web.Components.OptionProviders.DropdownEnum;

public class DropdownEnumOptionProvider<T> : IDropDownOptionsProvider where T : struct, Enum
{
    public Task<IEnumerable<DropDownOptionItem>> GetOptionItems()
    {
        var results = Enums.GetMembers<T>(EnumMemberSelection.All)
            .Select(enumItem =>
            {
                string text = enumItem.Attributes.OfType<DescriptionAttribute>().FirstOrDefault()?.Description ?? enumItem.Name;
                string value = enumItem.Value.ToString();

                return new DropDownOptionItem { Value = value, Text = text };
            });

        return Task.FromResult(results.AsEnumerable());
    }

    public virtual T Parse(string value, T defaultValue) =>
       Enums.TryParse<T>(value, true, out var parsed)
            ? parsed
            : defaultValue;
}