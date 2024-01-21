using Student.Architecture.Application.Repositories;
using Student.Architecture.Domain.Models;

namespace Student.Architecture.Application.Commands.Implementation;

public class DeleteCommandStudent : IDeleteCommandStudent<StudentEntity>
{
    private readonly IRepositoryStudent _repository;

    public DeleteCommandStudent(IRepositoryStudent repository)
    {
        _repository = repository;
    }

    void IDeleteCommandStudent<StudentEntity>.Delete(int id)
    {
        _repository.Delete(id);
    }
    
}