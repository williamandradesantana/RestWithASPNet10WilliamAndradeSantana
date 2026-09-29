using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;

namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = [];
}
