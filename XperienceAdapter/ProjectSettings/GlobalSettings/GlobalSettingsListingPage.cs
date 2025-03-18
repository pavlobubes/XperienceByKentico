using Kentico.Xperience.Admin.Base;
using CMS.Membership;
using Microsoft.Extensions.Localization;
using XperienceAdapter.Pages.ProjectSettings;
using XperienceAdapter.ProjectSettings.GlobalSettings;
using XperienceAdapter.Models.Classes.DancingGoat.GlobalSettingsKey;
using XperienceAdapter.Localization;

[assembly: UIPage(
    parentType: typeof(ProjectSettingsApplication),
    slug: "global-settings",
    uiPageType: typeof(GlobalSettingsListingPage),
    name: "Global settings",
    templateName: TemplateNames.LISTING,
    order: 0)]

namespace XperienceAdapter.ProjectSettings.GlobalSettings;

public class GlobalSettingsListingPage(IStringLocalizer<SharedResource> stringLocalizer) : ListingPage
{
    protected override string ObjectType => GlobalSettingsKeyInfo.OBJECT_TYPE;

    public override async Task ConfigurePage()
    {
        PageConfiguration.ColumnConfigurations
                    .AddColumn(nameof(GlobalSettingsKeyInfo.GlobalSettingsKeyDisplayName), stringLocalizer["Name"])
                    .AddColumn(nameof(GlobalSettingsKeyInfo.GlobalSettingsKeyValue), stringLocalizer["Value"])
                    .AddColumn(nameof(GlobalSettingsKeyInfo.GlobalSettingsKeyNote), stringLocalizer["Note"])
                    .AddColumn(nameof(GlobalSettingsKeyInfo.GlobalSettingsKeyName), stringLocalizer["Codename"]);

        PageConfiguration.HeaderActions.AddLink<GlobalSettingsCreatePage>(stringLocalizer["New setting"]);

        PageConfiguration.AddEditRowAction<GlobalSettingsEditSection>();

        PageConfiguration.TableActions
            .AddDeleteAction(nameof(Delete));

        await base.ConfigurePage();
    }

    // Ensure only a user with permissions to delete can perform the delete action.
    [PageCommand(Permission = SystemPermissions.DELETE)]
    public override Task<ICommandResponse<RowActionResult>> Delete(int id) => base.Delete(id);
}