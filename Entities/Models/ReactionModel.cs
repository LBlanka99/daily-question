using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class ReactionModel
{
    [Key]
    public Guid Id { get; set; }
    public AnswerModel Answer { get; set; }
    public UserModel User { get; set; }
    public ReactionType Type { get; set; }
}