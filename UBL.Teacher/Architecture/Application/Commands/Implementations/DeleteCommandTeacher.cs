using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Repositories;
using UBL.Teacher.Architecture.Domain.DomainServices;
using UBL.Teacher.Architecture.Domain.Models;

namespace UBL.Teacher.Architecture.Application.Commands.Implementations;

public class DeleteCommandTeacher : IDeleteCommand<TeacherEntity>
{
    private readonly IRepositoryTeacher _repository;
    
    public DeleteCommandTeacher(IRepositoryTeacher repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// This method deletes a teacher entity from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the teacher to be deleted.</param>
    void IDeleteCommand<TeacherEntity>.Delete(int id)
    {
        _repository.Delete(id);
    }

}