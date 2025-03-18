using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.UIPages;
using XperienceAdapter.Pages.ProjectSettings;

// Register the UI application pages - see a links and more details in the info box below.
[assembly: UIApplication(
    identifier: ProjectSettingsApplication.IDENTIFIER,
    type: typeof(ProjectSettingsApplication),
    slug: "project-settings",
    name: "Project settings",
    category: BaseApplicationCategories.CONFIGURATION,
    icon: Icons.BoxCogwheel,
    templateName: TemplateNames.SECTION_LAYOUT)]

namespace XperienceAdapter.Pages.ProjectSettings;

public class ProjectSettingsApplication : ApplicationPage
{
    public const string IDENTIFIER = "DancingGoat.ProjectSettingsApplication";
}