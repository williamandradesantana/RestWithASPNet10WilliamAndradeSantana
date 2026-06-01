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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string LastName { get; set; }

    //[JsonPropertyOrder(1)]
    public string Address { get; set; }

    [JsonConverter(typeof(GenderSerializer))]
    public string Gender { get; set; }

    [JsonConverter(typeof(DateSerializer))]
    [JsonIgnore]
    public DateTime? BirthDay { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
