using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
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
    
}