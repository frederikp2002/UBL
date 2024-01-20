namespace UBL.Teacher.Architecture.Application.Dtos;

public class UpdateRequestDtoTeacher
{
    public int TeacherId { get; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string Position { get;  set; }
    public string Address { get;  set; }
    public string City { get;  set; }
    public int ZipCode { get;  set; }
}