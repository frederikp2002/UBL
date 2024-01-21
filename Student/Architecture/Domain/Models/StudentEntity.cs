using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Architecture.Domain.Models;

public class StudentEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StudentId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? Email { get; private set; }
    public string? Address { get; private set; }
    public int? ZipCode { get; private set; }
    public DateTime? AdmissionDate { get; private set; }
    public DateTime? FinishedDate { get; private set; }
    public DateTime? Age { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentEntity"/> class.
    /// </summary>
    /// <param name="studentId">The unique identifier for the student.</param>
    /// <param name="firstName">The first name of the student.</param>
    /// <param name="lastName">The last name of the student.</param>
    /// <param name="email">The email of the student.</param>
    /// <param name="address">The address of the student.</param>
    /// <param name="zipCode">The zip code of the student's address.</param>
    public StudentEntity(int studentId, string firstName, string lastName, string email, string address, int zipCode)
    {

        if (!CheckIfValidEmail(email)) throw new Exception("Ugyldig email!");
        if (!CheckIfValidZipCode(zipCode)) throw new Exception("Ugyldigt postnummer!");
        
        this.StudentId = studentId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Address = address;
        this.ZipCode = zipCode;
    }

    /// <summary>
    /// Checks if the provided email is valid.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <returns>true if the email is valid; otherwise, false.</returns>
    private bool CheckIfValidEmail(string email)
    {
        if (email.Contains('@')) return true; 
        return false;
    }

    /// <summary>
    /// Checks if the provided zip code is valid.
    /// </summary>
    /// <param name="zipCode">The zip code to check.</param>
    /// <returns>true if the zip code is valid; otherwise, false.</returns>
    private bool CheckIfValidZipCode(int zipCode)
    {
        if (zipCode < 1000 || zipCode > 9999) { return false; }
        return true;
    }
    
}