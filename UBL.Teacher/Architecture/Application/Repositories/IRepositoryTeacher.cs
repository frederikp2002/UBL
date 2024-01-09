using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Domain.Models;

namespace UBL.Teacher.Architecture.Application.Repositories;

public interface IRepositoryTeacher
{
    void Create(TeacherEntity teacherEntity);
    void Delete(int id);
    QueryResultDtoTeacher Get(int id);
}