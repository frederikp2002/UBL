using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Repositories;
using UBL.Teacher.Architecture.Domain.DomainServices;
using UBL.Teacher.Architecture.Domain.Models;

namespace UBL.Teacher.Architecture.Application.Commands.Implementations;

public class CreateCommandTeacher : ICreateCommand<CreateRequestDtoTeacher>
{
    private readonly IRepositoryTeacher _repository;
    private readonly IDomainServiceTeacher _domainService;
    public CreateCommandTeacher(IRepositoryTeacher repository, IDomainServiceTeacher domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    void ICreateCommand<CreateRequestDtoTeacher>.Create(CreateRequestDtoTeacher createRequestDtoTeacher)
    {
        var entity = new TeacherEntity(_domainService, createRequestDtoTeacher.Id, createRequestDtoTeacher.FirstName,
            createRequestDtoTeacher.LastName, createRequestDtoTeacher.Email, createRequestDtoTeacher.Position,
            createRequestDtoTeacher.Address, createRequestDtoTeacher.City, createRequestDtoTeacher.ZipCode);
        _repository.Create(entity);
    }
}