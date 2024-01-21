using System.Collections.ObjectModel;
using Student.Architecture.Application.DTOs;
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
    
    /// <summary>
    /// Deletes a student in the repository.
    /// </summary>
    /// <param name="studentEntity">The student ID to be deleted.</param>
    void Delete(int id);

    /// <summary>
    /// Get a student in the repository.
    /// </summary>
    /// <param name="studentEntity">The student ID to get.</param>
    QueryResultDtoStudent Get(int id);

    IEnumerable<QueryResultDtoStudent> GetAll();

}