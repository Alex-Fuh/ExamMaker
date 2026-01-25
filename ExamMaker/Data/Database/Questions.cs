using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

[PrimaryKey(nameof(QuestionId))]
public class Questions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestionId { get; set; }
    [MaxLength(50)] 
    public string QuestionText { get; set; } = null!;

    public int TopicId { get; set; }
    [ForeignKey(nameof(TopicId))] 
    public required Topics Topic { get; set; }
}

public class TextQuestions : Questions
{
    // is empty, muss es aber geben. Um Fragentypen zu unterscheiden.
}

public class MultipleQuestions : Questions
{
    public List<AnswerOptions> Options { get; set; } = new();
    // new, damit es direkt eine Liste gibt, wenn eine Frage erstellt worden ist.
}

[PrimaryKey(nameof(AnswerOptionId))]
public class AnswerOptions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerOptionId { get; set; }
    
    public int QuestionId { get; set; }
    [ForeignKey(nameof(QuestionId))] 
    public  MultipleQuestions MultipleQuestion { get; set; } = null!;

    [MaxLength(50)] 
    public required string AnswerOptionText { get; set; }

    [DefaultValue(false)] // im Prinzip nur sowas wie ein Kommentar.
    public bool IsTrue { get; set; }
}