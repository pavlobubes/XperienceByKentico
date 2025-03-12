using Core;
using Infrastructure.ContentPage.Dto;

namespace Infrastructure.ContentPage.Repository;

public interface IContentPageRepository : IRepository
{
    Task<ContentPageDto?> GetContentPage(int WebPageItemID);

    Task<IEnumerable<ContentPageDto>> GetContentPages(string parentPath);
}