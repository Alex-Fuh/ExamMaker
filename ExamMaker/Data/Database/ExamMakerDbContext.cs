using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

public class ExamMakerDbContext(DbContextOptions<ExamMakerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Topics> Topics { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<TextQuestions> TextQuestions { get; set; }
    public DbSet<MultipleQuestions> MultipleQuestions { get; set; }
    public DbSet<AnswerOptions> AnswerOptions { get; set; }
    public DbSet<Answers> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Questions>()
            .HasDiscriminator<string>("question_type")
            .HasValue<TextQuestions>("text")
            .HasValue<MultipleQuestions>("multiple");

        base.OnModelCreating(modelBuilder); // maybe
    }
}