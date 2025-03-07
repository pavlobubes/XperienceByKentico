using Domain.HomePage;
using MediatR;

namespace Application.Home.Queries.GetHomeQuery;

public record GetHomeQuery(int WebPageItemID, string LanguageName) : IRequest<HomeModel> { }