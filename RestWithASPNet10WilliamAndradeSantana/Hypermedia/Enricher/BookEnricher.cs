using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Constants;

namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia.Enricher;

public class BookEnricher : ContentResponseEnricher<BookDTO>
{
    protected override Task EnrichModel(BookDTO content, IUrlHelper urlHelper)
    {
        var request = urlHelper.ActionContext.HttpContext.Request;
        var baseUrl =
            $"{request.Scheme}://{request.Host.ToUriComponent()}{request.PathBase.ToUriComponent()}/api/books/v1";
        content.Links.AddRange(GenerateLinks(content.Id, baseUrl));
        return Task.CompletedTask;
    }

    private IEnumerable<HyperMediaLink> GenerateLinks(long id, string baseUrl)
    {
        return new List<HyperMediaLink>
        {
            new()
            {
                Action = HttpActionVerb.GET,
                Href = $"{baseUrl}",
                Rel = RelationType.COLLECTION,
                Type = ResponseTypeFormat.DefautGet
            },
            new()
            {
                Action = HttpActionVerb.GET,
                Href = $"{baseUrl}/{id}",
                Rel = RelationType.SELF,
                Type = ResponseTypeFormat.DefautGet
            },
            new()
            {
                Action = HttpActionVerb.POST,
                Href = $"{baseUrl}",
                Rel = RelationType.CREATE,
                Type = ResponseTypeFormat.DefautPost
            },
            new()
            {
                Action = HttpActionVerb.PUT,
                Href = $"{baseUrl}/{id}",
                Rel = RelationType.UPDATE,
                Type = ResponseTypeFormat.DefautPut
            },
            new()
            {
                Action = HttpActionVerb.DELETE,
                Href = $"{baseUrl}/{id}",
                Rel = RelationType.DELETE,
                Type = ResponseTypeFormat.DefautDelete
            }
        };
    }
}
