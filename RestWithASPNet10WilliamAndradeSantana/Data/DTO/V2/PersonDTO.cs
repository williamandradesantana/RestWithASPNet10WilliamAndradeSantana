using RestWithASPNet10WilliamAndradeSantana.JsonSerializers;
using System.Text.Json.Serialization;

namespace RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;

public class PersonDTO
{
    [JsonPropertyName("code")]
    public long Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    //[JsonPropertyOrder(1)]
    public string Address { get; set; }
    public string Gender { get; set; }

    [JsonConverter(typeof(DateSerializer))]
    public DateTime? BirthDay { get; set; }
}
