using Microsoft.EntityFrameworkCore;
using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Repositories;
using UBL.Teacher.Architecture.Domain.Models;
using UBL.Teacher.Data;

namespace UBL.Teacher.Architecture.Infrastructure.Repositories;

public class RepositoryTeacher : IRepositoryTeacher
{
    private readonly TeacherContext _db;

    public RepositoryTeacher(TeacherContext db)
    {
        _db = db;
    }

    void IRepositoryTeacher.Create(TeacherEntity entity)
    {
        _db.Update(entity);
        _db.SaveChanges();
    }

    void IRepositoryTeacher.Delete(int id)
    {
        var dbEntity = _db.Teachers.AsNoTracking().FirstOrDefault(x => x.TeacherId == id);
        if (dbEntity == null) throw new Exception("Teacher does not exist in database!");
        _db.Teachers.Attach(dbEntity);
        _db.Teachers.Remove(dbEntity);
        _db.SaveChanges();
    }

    void IRepositoryTeacher.Update(TeacherEntity entity)
    {
        _db.Update(entity);
        _db.SaveChanges();
    }
    
    QueryResultDtoTeacher IRepositoryTeacher.Get(int id)
    {
        var dbEntity = _db.Teachers.AsNoTracking().FirstOrDefault(x => x.TeacherId == id);
        if (dbEntity == null) throw new Exception("Teacher does not exist in database!");

        return new QueryResultDtoTeacher()
        {
            FirstName = dbEntity.FirstName,
            LastName = dbEntity.LastName,
            Email = dbEntity.Email,
            Position = dbEntity.Position
        };
    }

    TeacherEntity IRepositoryTeacher.Load(int id)
    {
        var dbEntity = _db.Teachers.AsNoTracking().FirstOrDefault(x => x.TeacherId == id);
        if (dbEntity == null) throw new Exception("Teacher does not exist in database!!!");

        return dbEntity;
        
    }
    
}