using DancingGoat.Web.Components.Templates.Content;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using XperienceAdapter.Models.PageContentTypes.DancingGoat.Content;

//[assembly: RegisterPageTemplate(
//    identifier: ContentPageTemplate.IDENTIFIER,
//    name: "Product page template",
//    customViewName: "~/Views/Shared/Components/ContentPageTemplate/Default.cshtml",
//    ContentTypeNames = [Content.CONTENT_TYPE_NAME],
//    IconClass = "xp-box")]

namespace DancingGoat.Web.Components.Templates.Content;

public class ContentPageTemplate
{
    public const string IDENTIFIER = "DancingGoat.ContentPageTemplate";
}