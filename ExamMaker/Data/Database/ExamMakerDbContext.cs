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
    public DbSet<Users> Users { get; set; }
    public DbSet<Results> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // Für die verschiedenen Fragetypen.
        modelBuilder.Entity<Questions>()
            .HasDiscriminator<string>("question_type")
            .HasValue<TextQuestions>("text")
            .HasValue<MultipleQuestions>("multiple");
        
        // F[r die One to Many beziehung bei den MutlipleQuestions.
        modelBuilder.Entity<MultipleQuestions>()
            .HasMany(m => m.Options)
            .WithOne(o => o.MultipleQuestion)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);


        // Für Users, wird IsAdmin, automatisch auf false gesetzt. Per FluentAPI
        modelBuilder.Entity<Users>()
            .Property(u => u.IsAdmin)
            .HasDefaultValue(false);

        modelBuilder.Entity<AnswerOptions>()
            .Property(a => a.IsTrue)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<Results>()
            .Property(c => c.IsCorrected)
            .HasDefaultValue(false);

        base.OnModelCreating(modelBuilder); // maybe
    }
}