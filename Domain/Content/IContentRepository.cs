using Core;

namespace Domain.Content;
public interface IContentRepository : IRepository
{
    Task<ContentModel?> GetContent();
}