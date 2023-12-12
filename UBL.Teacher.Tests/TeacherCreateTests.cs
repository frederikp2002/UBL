using Moq;
using UBL.Teacher.Domain.Models;
using UBL.Teacher.Domain.DomainServices;

namespace UBL.Teacher.Tests;

public class TeacherCreateTests
{
    [Fact]
    public void Teacher_Already_Exists_In_System_Upon_Create_Then_Throw_Exception()
    {
        // Arrange
        var domainService = new Mock<IDomainServiceTeacher>();
    }

    // Test for invalid input on email 
    [Theory]
    [InlineData("")]
    [InlineData("d")]
    [InlineData("@domain.com")]
    [InlineData("user@")]
    [InlineData("user@domain")]
    public void If_Email_Is_Invalid_Then_Throw_ArgumentException(string email)
    {
        var mock = new Mock<IDomainServiceTeacher>();
        Assert.Throws<System.ArgumentException>(() => 
            new TeacherEntity(mock.Object, 5, "FirstNameTest", "LastNameTest", 
                email, "Teacher", "Sønderbrogade 81B, 1.", "Horsens", 8700));
    }
    
    [Theory]
    [InlineData(1000)]
    [InlineData(4000)]
    [InlineData(6000)]
    [InlineData(10000)]
    public void IfZipCodeIsInvalidThenThrowException(int zipCode)
    {
        var mock = new Mock<IDomainServiceTeacher>();
        var teacherModel = new TeacherEntity(mock.Object, 5, "FirstNameTest", "LastNameTest", 
                "emailTest@domain.com", "Teacher", "Sønderbrogade 81B, 1.", "Horsens", zipCode);

    }
    
}