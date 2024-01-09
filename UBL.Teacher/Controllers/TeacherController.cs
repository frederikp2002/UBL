using Microsoft.AspNetCore.Mvc;
using UBL.Teacher.Architecture.Application.Commands;
using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Queries;

namespace UBL.Teacher.Controllers;

public class TeacherController : Controller 
{

    private readonly ICreateCommand<CreateRequestDtoTeacher> _createCommandTeacher;
    private readonly IGetQuery<QueryResultDtoTeacher> _getQueryTeacher;
    public TeacherController(ICreateCommand<CreateRequestDtoTeacher> createCommandTeacher, IGetQuery<QueryResultDtoTeacher> getQueryTeacher)
    {
        _createCommandTeacher = createCommandTeacher;
        _getQueryTeacher = getQueryTeacher;
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QueryResultDtoTeacher> Get(int id)
    {
        try
        {
            var result = _getQueryTeacher.Get(id);
            return Ok(result);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }


}