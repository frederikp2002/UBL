namespace Student.Architecture.Application.Commands;

public interface ICreateCommandStudent<CreateRequestDto>
{
    void Create(DTOs.CreateRequestDtoStudent dtoStudent);
}