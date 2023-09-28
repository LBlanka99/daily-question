using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class QuestionModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public string Text { get; set; }
}