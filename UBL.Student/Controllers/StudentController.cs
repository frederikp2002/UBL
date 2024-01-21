using Microsoft.AspNetCore.Mvc;
using Student.Architecture.Application.Commands;
using Student.Architecture.Application.DTOs;
using Student.Architecture.Application.Queries;
using Student.Architecture.Domain.Models;

namespace Student.Controllers;

public class StudentController : Controller
{

    private readonly ICreateCommandStudent<CreateRequestDtoStudent> _createCommand;
    private readonly IDeleteCommandStudent<StudentEntity> _deleteCommand;
    private readonly IGetQueryStudent<QueryResultDtoStudent> _getQuery;
    private readonly IGetAllQueryStudent<QueryResultDtoStudent> _getAllQuery;

    public StudentController(ICreateCommandStudent<CreateRequestDtoStudent> createCommand, IDeleteCommandStudent<StudentEntity> deleteCommand, IGetQueryStudent<QueryResultDtoStudent> getQuery, IGetAllQueryStudent<QueryResultDtoStudent> getAllQuery)
    {
        _createCommand = createCommand;
        _deleteCommand = deleteCommand;
        _getQuery = getQuery;
        _getAllQuery = getAllQuery;
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

    /// <summary>
    /// Deletes a student upon giving a specific ID.
    /// </summary>
    /// <param name="id">The student ID that is needed to delete a specific student.</param>
    /// <returns>A response that confirms the deletion of the student or an error message.</returns>
    [HttpDelete("api/Delete")]
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
    /// Gets a student by ID.
    /// </summary>
    /// <param name="id">The student ID that is needed to get a specific student.</param>
    /// <returns>A response with the information of the student or an error message.</returns>
    [HttpGet("api/Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QueryResultDtoStudent> Get(int id)
    {
        try
        {
            var result = _getQuery.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    /// <summary>
    /// Gets all students.
    /// </summary>
    /// <returns>A response with the information of all students or an error message.</returns>
    [HttpGet("api/GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<QueryResultDtoStudent>> GetAll()
    {
        try
        {
            var result = _getAllQuery.GetAll().ToList();
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}