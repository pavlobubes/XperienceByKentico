using Kentico.Xperience.Admin.Base;

namespace XperienceAdapter;

internal class AcmeWebAdminModule : AdminModule
{
    public const string CUSTOM_CATEGORY = "acme.web.admin.category";

    public AcmeWebAdminModule()
        : base("Acme.Web.Admin")
    {
    }

    protected override void OnInit()
    {
        base.OnInit();

        // Makes the module accessible to the admin UI
        RegisterClientModule("acme", "web-admin");
    }
}