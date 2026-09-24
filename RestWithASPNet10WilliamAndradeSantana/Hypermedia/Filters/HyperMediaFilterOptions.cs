using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;

namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public List<IReponseEnricher> ContentResponseEnricherList { get; set; } = [];
}
