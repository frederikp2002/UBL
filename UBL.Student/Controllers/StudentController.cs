using Microsoft.AspNetCore.Mvc;
using Student.Architecture.Application.Commands;
using Student.Architecture.Application.DTOs;

namespace Student.Controllers;

public class StudentController : Controller
{

    private readonly ICreateCommandStudent<CreateRequestDtoStudent> _createCommand;

    public StudentController(ICreateCommandStudent<CreateRequestDtoStudent> createCommand)
    {
        _createCommand = createCommand;
    }

    /// <summary>
    /// Creates a new student.
    /// </summary>
    /// <param name="createRequestDtoStudent">The student data transfer object.</param>
    /// <returns>A response with the created student or an error message.</returns>
    [HttpPost("api/Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post([FromBody] CreateRequestDtoStudent createRequestDtoStudent)
    {
        try
        {
            _createCommand.Create(createRequestDtoStudent);
            return Created("", createRequestDtoStudent);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}