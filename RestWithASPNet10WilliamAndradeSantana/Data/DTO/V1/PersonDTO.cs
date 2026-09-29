using RestWithASPNet10WilliamAndradeSantana.Hypermedia;
using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Abstract;

namespace RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;

public class PersonDTO : ISupportsHypermedia
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public bool Enabled { get; set; }
    public List<HyperMediaLink> Links { get; set; } = [];
}