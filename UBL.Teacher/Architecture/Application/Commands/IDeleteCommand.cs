namespace UBL.Teacher.Architecture.Application.Commands;

public interface IDeleteCommand<T>
{
    void Delete(int id);
}