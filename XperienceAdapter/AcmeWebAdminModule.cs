using Kentico.Xperience.Admin.Base;

namespace XperienceAdapter;

internal class AcmeWebAdminModule() : AdminModule("Acme.Web.Admin")
{
    public const string CUSTOM_CATEGORY = "acme.web.admin.category";

    protected override void OnInit()
    {
        base.OnInit();
        RegisterClientModule("acme", "web-admin");
    }
}
