namespace UBL.Teacher.Architecture.Application.Commands;

public interface ICreateCommand<T>
{
    void Create(T dto);
}