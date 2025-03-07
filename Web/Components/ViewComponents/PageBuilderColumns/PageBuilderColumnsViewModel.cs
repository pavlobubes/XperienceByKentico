using System.Collections.Generic;

namespace DancingGoat.Web.Components.ViewComponents.PageBuilderColumns;

public class PageBuilderColumnsViewModel
{
    public PageBuilderAreaType PageBuilderAreaType { get; set; }


    public IEnumerable<PageBuilderColumnViewModel> PageBuilderColumns = [];
}