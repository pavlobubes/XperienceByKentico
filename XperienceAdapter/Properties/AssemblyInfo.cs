using Kentico.Xperience.Admin.Base;
using XperienceAdapter;

[assembly: CMS.AssemblyDiscoverable]
[assembly: CMS.RegisterModule(typeof(AcmeWebAdminModule))]

// Adds a new application category 
[assembly: UICategory(AcmeWebAdminModule.CUSTOM_CATEGORY, "Custom", Icons.CustomElement, 100)]