namespace UBL.Teacher.Architecture.Application.Dtos;

public class CreateRequestDtoTeacher
{
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Position { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public int ZipCode { get; private set; }
}