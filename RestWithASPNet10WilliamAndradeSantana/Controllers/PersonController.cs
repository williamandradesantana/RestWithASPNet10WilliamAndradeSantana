using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Services;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers;

[ApiController]
[Route("api/people")]
public class PersonController : ControllerBase
{
    private IPersonServices _personServices;

    public PersonController(IPersonServices personServices)
    {
        _personServices = personServices;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        var persons = _personServices.FindAll();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] long id)
    {
        var createdPerson = _personServices.FindById(id);
        if (createdPerson == null) return NotFound();
        return Ok(createdPerson);
    }

    [HttpPost]
    public IActionResult CreatePerson([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        var createdPerson = _personServices.CreatePerson(person);
        return CreatedAtAction(nameof(FindById), new { Id = person.Id }, createdPerson);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatedPerson([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        var updatedPerson = _personServices.UpdatePerson(person);
        if (updatedPerson == null) return NotFound();
        return Ok(updatedPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson([FromRoute] int id)
    {
        _personServices.DeletePerson(id);
        return NoContent();
    }
}
