using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;

namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia;

public abstract class ContentResponseEnricher<T>
    : IResponseEnricher where T : ISupportsHypermedia
{
    public virtual bool CanEnrich(Type contentType)
    {
        return contentType == typeof(T) || contentType == typeof(List<T>);
    }

    protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);
    
    bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
    {
        if (response.Result is OkObjectResult okObjectResult)
            return CanEnrich(okObjectResult.Value.GetType());
        
        return false;
    }

    public async Task Enrich(ResultExecutingContext response)
    {
        var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
        if (urlHelper is OkObjectResult okObjectResult)
        {
            if (okObjectResult.Value is T model)
            {
                await EnrichModel(model, urlHelper);
            }
            else if (okObjectResult.Value is List<T> collection)
            {
                foreach (var element in collection)
                {
                    await EnrichModel(element, urlHelper);
                }
            }
        }
        await Task.CompletedTask;
    }
}
