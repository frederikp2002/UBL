using Student.Architecture.Application.DTOs;
using Student.Architecture.Application.Repositories;
using Student.Architecture.Domain.Models;

namespace Student.Architecture.Application.Commands.Implementation
{
    /// <summary>
    /// This class is responsible for creating a new student entity.
    /// It implements the ICreateCommand interface with CreateRequestDto as the type parameter.
    /// </summary>
    public class CreateCommandStudent : ICreateCommandStudent<CreateRequestDtoStudent>
    {
        private readonly IRepositoryStudent _repository;

        /// <summary>
        /// Initializes a new instance of the CreateCommand class.
        /// </summary>
        /// <param name="repository">The repository where the student entity will be stored.</param>
        public CreateCommandStudent(IRepositoryStudent repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates a new student entity and stores it in the repository.
        /// </summary>
        /// <param name="createRequestDtoStudent">The data transfer object containing the details of the student to be created.</param>
        void ICreateCommandStudent<CreateRequestDtoStudent>.Create(CreateRequestDtoStudent createRequestDtoStudent)
        {
            var entity = new StudentEntity(createRequestDtoStudent.StudentId, createRequestDtoStudent.FirstName,
                createRequestDtoStudent.LastName, createRequestDtoStudent.Email, createRequestDtoStudent.Address, createRequestDtoStudent.ZipCode,
                createRequestDtoStudent.AdmissionDate, createRequestDtoStudent.FinishedDate, createRequestDtoStudent.Age);

            _repository.Create(entity);
        }
    }
}