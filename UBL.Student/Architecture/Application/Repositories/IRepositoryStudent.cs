using Student.Architecture.Domain.Models;

namespace Student.Architecture.Application.Repositories;

/// <summary>
/// Defines a contract for a repository handling operations related to StudentEntity.
/// </summary>
public interface IRepositoryStudent
{
    /// <summary>
    /// Creates a new student in the repository.
    /// </summary>
    /// <param name="studentEntity">The student entity to be created.</param>
    void Create(StudentEntity studentEntity);
}