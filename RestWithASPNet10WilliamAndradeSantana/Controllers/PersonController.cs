using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Services;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers;

[ApiController]
[Route("api/people")]
public class PersonController : ControllerBase
{
    private IPersonServices _personServices;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
    {
        _personServices = personServices;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        _logger.LogInformation("Fetching all people");
        var persons = _personServices.FindAll();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] long id)
    {
        _logger.LogInformation("Fetching person with {id}", id);
        var createdPerson = _personServices.FindById(id);
        if (createdPerson == null) 
        { 
            _logger.LogWarning("Person with {id} not found", id);
            return NotFound(); 
        }
        return Ok(createdPerson);
    }

    [HttpPost]
    public IActionResult CreatePerson([FromBody] Person person)
    {
        _logger.LogInformation("Creating new person: {firstName}", person.FirstName);
        if (person == null) 
        { 
            _logger.LogWarning("Received null person object for creation");
            return BadRequest(); 
        }
        var createdPerson = _personServices.CreatePerson(person);
        return CreatedAtAction(nameof(FindById), new { Id = person.Id }, createdPerson);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatedPerson([FromBody] Person person)
    {
        _logger.LogInformation("Updating person with {id}", person.Id);
        if (person == null) 
        {
            _logger.LogWarning("Received null person object for update");
            return BadRequest(); 
        }
        var updatedPerson = _personServices.UpdatePerson(person);
        if (updatedPerson == null) 
        {
            _logger.LogWarning("Person with {id} not found for update", person.Id);
            return NotFound(); 
        }
        _logger.LogDebug("Person with {id} updated successfully", person.Id);
        return Ok(updatedPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson([FromRoute] int id)
    {
        _logger.LogInformation("Deleting person with {id}", id);
        _personServices.DeletePerson(id);
        _logger.LogDebug("Person with {id} deleted successfully", id);
        return NoContent();
    }
}
