using Microsoft.AspNetCore.Mvc;
using UBL.Teacher.Architecture.Application.Commands;
using UBL.Teacher.Architecture.Application.Dtos;

namespace UBL.Teacher.Controllers;

public class TeacherController : Controller 
{

    private readonly ICreateCommand<CreateRequestDtoTeacher> _createCommandTeacher;

    public TeacherController(ICreateCommand<CreateRequestDtoTeacher> createCommandTeacher)
    {
        _createCommandTeacher = createCommandTeacher;
    }
    
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post([FromBody] CreateRequestDtoTeacher createRequestDtoTeacher)
    {
        try
        {
            _createCommandTeacher.Create(createRequestDtoTeacher);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}