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

    QueryResultDtoTeacher IGetQuery<QueryResultDtoTeacher>.Get(int id)
    {
        return _repository.Get(id);
    }
    
}