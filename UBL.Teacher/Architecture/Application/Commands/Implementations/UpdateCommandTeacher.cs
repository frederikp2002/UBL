using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Repositories;

namespace UBL.Teacher.Architecture.Application.Commands.Implementations;

public class UpdateCommandTeacher : IUpdateCommand<UpdateRequestDtoTeacher>
{
    private readonly IRepositoryTeacher _repository;
    public UpdateCommandTeacher(IRepositoryTeacher repository)
    {
        _repository = repository;
    }

    void IUpdateCommand<UpdateRequestDtoTeacher>.Update(UpdateRequestDtoTeacher updateRequestDto)
    {
        var model = _repository.Load(updateRequestDto.TeacherId);
        
        model.Update(updateRequestDto.FirstName, updateRequestDto.LastName, updateRequestDto.Email,
            updateRequestDto.Position, updateRequestDto.Address, updateRequestDto.City, updateRequestDto.ZipCode);

        _repository.Update(model);

    }

}