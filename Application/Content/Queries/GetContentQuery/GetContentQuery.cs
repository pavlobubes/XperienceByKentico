using Domain.Content;
using MediatR;

namespace Application.Content.Queries.GetContentQuery;

public record GetContentQuery(int WebPageItemID, string LanguageName, string WebsiteChannelName) : IRequest<ContentModel> { }