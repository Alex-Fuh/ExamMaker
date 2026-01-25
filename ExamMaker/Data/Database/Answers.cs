using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

[PrimaryKey(nameof(AnswerId))]
public class Answers
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerId { get; set; }
    
    public int QuestionId { get; set; }
    [ForeignKey(nameof(QuestionId))]
    public Questions Question { get; set; } = null!;
    
    // Text.
    [MaxLength(50)]
    public string? FreeText { get; set; }
    
    // Multiple-Chice, es geht aber nur eine Antwwort.
    public int? SelectedAnswerOptionId { get; set; }
    public AnswerOptions? SelectedAnswerOption { get; set; }
    
}