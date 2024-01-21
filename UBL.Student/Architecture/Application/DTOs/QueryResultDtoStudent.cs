namespace Student.Architecture.Application.DTOs;

public class QueryResultDtoStudent
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set;  }
    public int? ZipCode { get; set; }
    public DateTime? AdmissionDate { get; set;  }
    public DateTime? FinishedDate { get; set;  }
    public DateTime? Age { get; set; }
}