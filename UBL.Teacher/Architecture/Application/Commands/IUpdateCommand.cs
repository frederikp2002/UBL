namespace UBL.Teacher.Architecture.Application.Commands;

public interface IUpdateCommand<T>
{
    void Update(T Dto);
}