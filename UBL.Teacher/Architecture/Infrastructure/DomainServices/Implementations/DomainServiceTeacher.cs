using UBL.Teacher.Architecture.Domain.DomainServices;
using UBL.Teacher.Data;

namespace UBL.Teacher.Architecture.Infrastructure.DomainServices.Implementations;

public class DomainServiceTeacher : IDomainServiceTeacher
{

    private readonly TeacherContext _db;

    public DomainServiceTeacher(TeacherContext db)
    {
        _db = db;
    }

    public bool TeacherInDatabase(int id)
    {
        if (_db.Teachers.Any(x => x.TeacherId == id))
        {
            return true;
        }

        return false;
    }
    
    
    
}