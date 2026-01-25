using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMaker.Data.Database;

public class Results
{
    public int ResultId { get; set; }
    public bool IsCorrected { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] 
    public Users User { get; set; } = null!;
    
    public int AnswerId { get; set; }
    [ForeignKey(nameof(AnswerId))] 
    public Answers Answer { get; set; } = null!;
}