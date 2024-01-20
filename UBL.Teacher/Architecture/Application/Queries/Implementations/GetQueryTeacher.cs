using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Repositories;

namespace UBL.Teacher.Architecture.Application.Queries.Implementations;

public class GetQueryTeacher : IGetQuery<QueryResultDtoTeacher>
{
    private readonly IRepositoryTeacher _repository;

    public GetQueryTeacher(IRepositoryTeacher repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// This method retrieves a teacher entity from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the teacher to be retrieved.</param>
    /// <returns>Returns a data transfer object containing the details of the retrieved teacher.</returns>
    QueryResultDtoTeacher IGetQuery<QueryResultDtoTeacher>.Get(int id)
    {
        return _repository.Get(id);
    }
    
}