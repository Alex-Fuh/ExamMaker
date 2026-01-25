using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;


[PrimaryKey(nameof(TopicId))]
public class Topics
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int TopicId { get; set; }
    [MaxLength(50)]
    public required string TopicName { get; set; }
}