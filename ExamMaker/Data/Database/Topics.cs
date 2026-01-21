using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;


[PrimaryKey(nameof(TopicId))]
public class Topics
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int TopicId { get; set; }
    public string? TopicName { get; set; }
}