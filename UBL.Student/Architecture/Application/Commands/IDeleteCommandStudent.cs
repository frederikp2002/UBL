namespace Student.Architecture.Application.Commands;

public interface IDeleteCommandStudent<StudentEntity>
{
    void Delete(int id);
}