using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

public class ExamMakerDbContext(DbContextOptions<ExamMakerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }
    public DbSet<User> Test { get; set; }
}