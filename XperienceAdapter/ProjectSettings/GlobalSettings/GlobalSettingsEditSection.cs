using Kentico.Xperience.Admin.Base;
using XperienceAdapter.ProjectSettings.GlobalSettings;
using XperienceAdapter.Models.Classes.DancingGoat.GlobalSettingsKey;

// Register the UI page as child of GlobalSettingsListingPage.
[assembly: UIPage(
    parentType: typeof(GlobalSettingsListingPage),
    slug: PageParameterConstants.PARAMETERIZED_SLUG,
    uiPageType: typeof(GlobalSettingsEditSection),
    name: "Edit",
    templateName: TemplateNames.SECTION_LAYOUT,
    order: 10)]

namespace XperienceAdapter.ProjectSettings.GlobalSettings;

public class GlobalSettingsEditSection : EditSectionPage<GlobalSettingsKeyInfo>
{ }