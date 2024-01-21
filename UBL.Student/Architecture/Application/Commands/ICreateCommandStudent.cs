using Student.Architecture.Application.DTOs;

namespace Student.Architecture.Application.Commands;

public interface ICreateCommandStudent<CreateRequestDtoStudent>
{
    void Create(CreateRequestDtoStudent dtoStudent);
}