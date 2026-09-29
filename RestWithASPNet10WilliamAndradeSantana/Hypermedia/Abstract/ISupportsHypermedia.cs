namespace RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;
    
public interface ISupportsHypermedia
{
    List<HyperMediaLink> Links { get; set; }
}
