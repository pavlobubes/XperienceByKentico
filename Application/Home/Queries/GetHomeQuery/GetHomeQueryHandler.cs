using Domain.Home;
using Domain.HomePage;
using MediatR;

namespace Application.Home.Queries.GetHomeQuery;

public class GetHomeQueryHandler(IHomeRepository homeRepository) : IRequestHandler<GetHomeQuery, HomeModel>
{
    public async Task<HomeModel> Handle(GetHomeQuery request, CancellationToken cancellationToken)
    {
        var homePage = await homeRepository.GetHome();
        return homePage;
    }
}