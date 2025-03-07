using Domain.Content;
using MediatR;

namespace Application.Content.Queries.GetContentQuery;

public record GetContentQuery() : IRequest<ContentModel> { }