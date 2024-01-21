using Student.Architecture.Application.DTOs;

namespace Student.Architecture.Application.Queries;

public interface IGetQueryStudent<queryresultdtostudent>
{
    QueryResultDtoStudent Get(int id);
}