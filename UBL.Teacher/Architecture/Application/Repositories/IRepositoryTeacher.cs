using UBL.Teacher.Architecture.Domain.Models;

namespace UBL.Teacher.Architecture.Application.Repositories;

public interface IRepositoryTeacher
{
    void Create(TeacherEntity teacherEntity);

}