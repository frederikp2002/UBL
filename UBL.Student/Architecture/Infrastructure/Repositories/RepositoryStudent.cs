using Student.Architecture.Application.DTOs;
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

    /// <summary>
    /// Deletes a student in the database.
    /// </summary>
    /// <param name="entity">The student id to be deleted.</param>
    void IRepositoryStudent.Delete(int id)
    { 
        var dbEntity = _db.Students.Find(id);
        if (dbEntity == null) throw new Exception("This Student does not exist in the database!");

        _db.Students.Remove(dbEntity);
        _db.SaveChanges();
    }

    /// <summary>
    /// Gets a student entity in the database.
    /// </summary>
    /// <param name="entity">The student entity to get.</param>
    QueryResultDtoStudent IRepositoryStudent.Get(int id)
    {
        var dbEntity = _db.Students.Find(id);
        if (dbEntity == null) throw new Exception("This Student does not exist in the database!");

        return new QueryResultDtoStudent()
        {
            StudentId = dbEntity.StudentId,
            FirstName = dbEntity.FirstName,
            LastName = dbEntity.LastName,
            Email = dbEntity.Email,
            Address = dbEntity.Address,
            ZipCode = dbEntity.ZipCode,
            AdmissionDate = dbEntity.AdmissionDate,
            FinishedDate = dbEntity.FinishedDate,
            Age = dbEntity.Age
        };

    }
    
}