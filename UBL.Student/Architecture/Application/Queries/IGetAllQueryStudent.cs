using System.Collections.ObjectModel;
using Student.Architecture.Application.Queries.Implementations;

namespace Student.Architecture.Application.Queries;

public interface IGetAllQueryStudent<T>
{
    IEnumerable<T> GetAll();
}