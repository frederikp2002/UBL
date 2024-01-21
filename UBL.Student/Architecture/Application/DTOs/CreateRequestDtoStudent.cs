namespace Student.Architecture.Application.DTOs;

/// <summary>
/// Represents the data transfer object for creating a student.
/// </summary>
public class CreateRequestDtoStudent
{
    public int StudentId { get; private set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string? Address { get; set; }
    public int ZipCode { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime FinishedDate { get; set; }
    public DateTime Age { get; set; }
}