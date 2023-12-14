using System.ComponentModel.DataAnnotations;
using UBL.Teacher.Architecture.Domain.DomainServices;

namespace UBL.Teacher.Architecture.Domain.Models;

public class TeacherEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string? Position { get; private set; }
    public string? Address { get; private set; }
    public string? City { get; private set; }
    public int? ZipCode { get; private set; }
    public DateTime HireDate { get; private set; }
    public DateTime TerminationDate { get; private set; }

    private readonly IDomainServiceTeacher _domainServiceTeacher;

    public TeacherEntity(IDomainServiceTeacher domainServiceTeacher, int id, string firstName, string lastName, string email, string position, string address, string city, int zipCode)
    {
        if (!CheckIfValidEmail(email)) { throw new ArgumentException("Invalid email"); }
        if (!CheckIfValidPosition(position)) { throw new ArgumentException("Invalid position"); }
        if (!CheckIfValidZipCode(zipCode)) { throw new ArgumentException("Invalid zip code"); }

        _domainServiceTeacher = domainServiceTeacher;

        if (_domainServiceTeacher.TeacherInDatabase(id)) { throw new ArgumentException("This teacher is already registered in the system!"); }
        
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Position = position;
        this.Address = address;
        this.City = city;
        this.ZipCode = zipCode;
        
    }
    internal TeacherEntity(){}
    
    /// <summary>
    /// Checks if the given email is valid.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <returns>True if the email is valid, otherwise false.</returns>
    // TODO: Check for more than just a "@" character
    private bool CheckIfValidEmail(string email)
    {
        if (email.Contains('@'))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if the given zip code is valid.
    /// </summary>
    /// <param name="zipCode">The zip code to be checked.</param>
    /// <returns>True if the zip code is valid; otherwise, false.</returns>
    private bool CheckIfValidZipCode(int zipCode)
    {
        if (zipCode < 1000 || zipCode > 9999)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Checks if the given position is valid.
    /// </summary>
    /// <param name="position">The position to be checked.</param>
    /// <returns>
    /// <c>true</c> if the position is valid; otherwise, <c>false</c>.
    /// </returns>
    private bool CheckIfValidPosition(string position)
    {
        if (position == "Teacher" || position == "Assistant" || position == "Administrator")
        {
            return true;
        }
        return false;
    }
}