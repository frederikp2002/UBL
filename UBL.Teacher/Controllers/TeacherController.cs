using Microsoft.AspNetCore.Mvc;
using UBL.Teacher.Architecture.Application.Commands;
using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Queries;
using UBL.Teacher.Architecture.Domain.Models;

namespace UBL.Teacher.Controllers;

public class TeacherController : Controller 
{

    private readonly ICreateCommand<CreateRequestDtoTeacher> _createCommand;
    private readonly IDeleteCommand<TeacherEntity> _deleteCommand;
    private readonly IGetQuery<QueryResultDtoTeacher> _getQueryTeacher;
    public TeacherController(ICreateCommand<CreateRequestDtoTeacher> createCommand, IDeleteCommand<TeacherEntity> deleteCommand, IGetQuery<QueryResultDtoTeacher> getQueryTeacher)
    {
        _createCommand = createCommand;
        _deleteCommand = deleteCommand;
        _getQueryTeacher = getQueryTeacher;
    }
    
    /// <summary>
    /// This method is a POST endpoint that creates a new teacher record.
    /// </summary>
    /// <param name="createRequestDtoTeacher">A data transfer object containing the details of the teacher to be created.</param>
    /// <returns>
    /// Returns a 201 (Created) status code if the teacher record was successfully created.
    /// Returns a 400 (Bad Request) status code if there was an error during the creation of the teacher record.
    /// </returns>
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post([FromBody] CreateRequestDtoTeacher createRequestDtoTeacher)
    {
        try
        {
            _createCommand.Create(createRequestDtoTeacher);
            return Created("", createRequestDtoTeacher);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// This method is a DELETE endpoint that removes a teacher record.
    /// </summary>
    /// <param name="id">The unique identifier of the teacher to be deleted.</param>
    /// <returns>
    /// Returns a 200 (OK) status code if the teacher record was successfully deleted.
    /// Returns a 400 (Bad Request) status code if there was an error during the deletion of the teacher record.
    /// </returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Delete(int id)
    {
        try
        {
            _deleteCommand.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// This method is a GET endpoint that retrieves a teacher record.
    /// </summary>
    /// <param name="id">The unique identifier of the teacher to be retrieved.</param>
    /// <returns>
    /// Returns a 200 (OK) status code with the teacher record if it was successfully retrieved.
    /// Returns a 404 (Not Found) status code if there was an error during the retrieval of the teacher record.
    /// </returns>
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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Put(int id, [FromBody] UpdateRequestDtoTeacher updateRequestDtoTeacher)
    {
        try
        {
            _updateCommand.Update(id, updateRequestDtoTeacher);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}