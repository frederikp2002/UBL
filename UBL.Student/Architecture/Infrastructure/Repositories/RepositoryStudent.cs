using Student.Architecture.Application.Repositories;
using Student.Architecture.Domain.Models;
using Student.Data;

namespace Student.Architecture.Infrastructure.Repositories;

/// <summary>
/// RepositoryStudent class implements IRepositoryStudent interface.
/// </summary>
public class RepositoryStudent : IRepositoryStudent
{
    private readonly StudentContext _db;

    /// <summary>
    /// Initializes a new instance of the RepositoryStudent class.
    /// </summary>
    /// <param name="db">The database context.</param>
    public RepositoryStudent(StudentContext db)
    {
        _db = db;
    }
    /// <summary>
    /// Creates a new student entity in the database.
    /// </summary>
    /// <param name="entity">The student entity to be created.</param>
    void IRepositoryStudent.Create(StudentEntity entity)
    {
        _db.Update(entity);
        _db.SaveChanges();
    }
    
}