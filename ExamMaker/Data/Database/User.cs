using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

[PrimaryKey(nameof(Id))]
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool Is_Admin { get; set; }
}