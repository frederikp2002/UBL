namespace UBL.Teacher.Architecture.Application.Queries;

public interface IGetQuery<T>
{
    T Get(int id);
}