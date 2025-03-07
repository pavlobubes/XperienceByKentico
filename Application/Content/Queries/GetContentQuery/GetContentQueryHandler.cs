using Domain.Content;
using MediatR;

namespace Application.Content.Queries.GetContentQuery;

public class GetContentQueryHandler(IContentRepository contentRepository) : IRequestHandler<GetContentQuery, ContentModel?>
{
    public async Task<ContentModel?> Handle(GetContentQuery request, CancellationToken cancellationToken)
    {
        var contentPage = await contentRepository.GetContent();
        return contentPage;
    }
}