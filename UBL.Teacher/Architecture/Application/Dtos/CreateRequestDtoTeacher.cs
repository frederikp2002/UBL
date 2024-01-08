namespace UBL.Teacher.Architecture.Application.Dtos;

public class CreateRequestDtoTeacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public int ZipCode { get; set; }
}