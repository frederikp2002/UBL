namespace UBL.Teacher.Models;

public class TeacherEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Position { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public int ZipCode { get; private set; }
    public DateTime HireDate { get; private set; }
    public DateTime TerminationDate { get; private set; }

    public TeacherEntity(Guid id, string firstName, string lastName, string email, string position, string address, string city, int zipCode)
    {
        if (!CheckIfValidEmail(email)) { throw new ArgumentException("Invalid email"); }
        if (!CheckIfValidPosition(position)) { throw new ArgumentException("Invalid position"); }
        if (!CheckIfValidZipCode(zipCode)) { throw new ArgumentException("Invalid zip code"); }
        
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Position = position;
        this.Address = address;
        this.City = city;
        this.ZipCode = zipCode;
        
    }
    
    /// <summary>
    /// Checks if the passed string is a valid email.
    /// </summary>
    /// <param name="email">String possibly representing an email.</param>
    /// <returns>True if the string contains the '@' character. Otherwise, returns False.</returns>
    private bool CheckIfValidEmail(string email)
    {
        if (email.Contains('@'))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if the passed integer is a valid zip code.
    /// </summary>
    /// <param name="zipCode">Integer possibly representing a zip code.</param>
    /// <returns>True if the passed integer is within the range of 1000 to 9999. Otherwise, returns False.</returns>
    private bool CheckIfValidZipCode(int zipCode)
    {
        if (zipCode < 1000 || zipCode > 9999)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Checks if the passed string is a valid position.
    /// </summary>
    /// <param name="position">String possibly representing a position.</param>
    /// <returns>True if the passed string matches either "Teacher", "Assistant", or "Administrator". Otherwise, returns False.</returns>
    private bool CheckIfValidPosition(string position)
    {
        if (position == "Teacher" || position == "Assistant" || position == "Administrator")
        {
            return true;
        }
        return false;
    }
    
}