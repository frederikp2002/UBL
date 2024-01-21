using Microsoft.EntityFrameworkCore;
using Student.Architecture.Domain.Models;

namespace Student.Data;

public class StudentContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; } = null!;
    
    private string password = "0GlPo[)(eJU7sOk}UTza";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: THIS IS BAD PRACTICE, PLEASE REMOVE CONNECTIONSTRING AND MAKE IT MORE SECURE
        optionsBuilder.UseMySql($"server=127.0.0.1;port=3306;user=root;password={password};database=database_teacher", new MySqlServerVersion(new Version(8, 2, 0)));
    }

}