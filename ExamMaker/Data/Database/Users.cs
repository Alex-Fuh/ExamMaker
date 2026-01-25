using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker.Data.Database;

[PrimaryKey(nameof(UserId))]
public class Users
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    [MaxLength(15)]
    public required string Name { get; set; }
    [MaxLength(255)]
    public required string PasswordHash { get; set; }

    [DefaultValue(false)] // Im Prinzip nur sowas wie ein Kommentar
    public bool IsAdmin { get; set; }
}