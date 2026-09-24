using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;

public interface IReponseEnricher
{
    bool CanEnrich(ResultExecutingContext context);
    Task Enrich(ResultExecutingContext context);
}
