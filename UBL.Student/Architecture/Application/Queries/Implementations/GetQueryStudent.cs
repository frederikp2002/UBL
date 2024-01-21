using Student.Architecture.Application.DTOs;
using Student.Architecture.Application.Repositories;

namespace Student.Architecture.Application.Queries.Implementations;

public class GetQueryStudent : IGetQueryStudent<QueryResultDtoStudent>
{
    private readonly IRepositoryStudent _repository;

    public GetQueryStudent(IRepositoryStudent repository)
    {
        _repository = repository;
    }

    QueryResultDtoStudent IGetQueryStudent<QueryResultDtoStudent>.Get(int id)
    {
        return _repository.Get(id);
    }
    
}