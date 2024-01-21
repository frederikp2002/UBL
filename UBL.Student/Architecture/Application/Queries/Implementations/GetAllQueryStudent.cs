using System.Collections.ObjectModel;
using Student.Architecture.Application.DTOs;
using Student.Architecture.Application.Repositories;

namespace Student.Architecture.Application.Queries.Implementations;

public class GetAllQueryStudent : IGetAllQueryStudent<QueryResultDtoStudent>
{
    private readonly IRepositoryStudent _repository;

    public GetAllQueryStudent(IRepositoryStudent repository)
    {
        _repository = repository;
    }

    IEnumerable<QueryResultDtoStudent> IGetAllQueryStudent<QueryResultDtoStudent>.GetAll()
    {
        return _repository.GetAll();
    }
    
}