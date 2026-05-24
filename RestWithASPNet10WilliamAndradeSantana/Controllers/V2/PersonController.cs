using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;
using RestWithASPNet10WilliamAndradeSantana.Services;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers.V2;

[ApiController]
[Route("api/people/v2")]
public class PersonController : ControllerBase
{
    private IPersonServicesV2 _personServices;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonServicesV2 personServices, ILogger<PersonController> logger)
    {
        _personServices = personServices;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Fetching all persons");
        return Ok(_personServices.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Fetching person with ID {id}", id);
        var person = _personServices.FindById(id);
        if (person == null)
        {
            _logger.LogWarning("Person with ID {id} not found", id);
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);

        var createdPerson = _personServices.Create(person);
        if (createdPerson == null)
        {
            _logger.LogError("Failed to create person with name {firstName}", person.FirstName);
            return NotFound();
        }
        return Ok(createdPerson);
    }

    [HttpPut]
    public IActionResult Put([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Updating person with ID {id}", person.Id);

        var createdPerson = _personServices.Update(person);
        if (createdPerson == null)
        {
            _logger.LogError("Failed to update person with ID {id}", person.Id);
            return NotFound();
        }
        _logger.LogDebug("Person updated successfully: {firstName}", createdPerson.FirstName);
        return Ok(createdPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting person with ID {id}", id);
        _personServices.Delete(id);
        _logger.LogDebug("Person with ID {id} deleted successfully", id);
        return NoContent();
    }
}
