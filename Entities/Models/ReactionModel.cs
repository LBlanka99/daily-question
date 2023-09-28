using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Models;

public class ReactionModel
{
    [Key]
    [Column(Order = 1)]
    public Guid AnswerId { get; set; }
    
    [Key]
    [Column(Order = 2)]
    public Guid UserId { get; set; }
    
    public ReactionType Type { get; set; }
    
    [ForeignKey(nameof(AnswerId))]
    public AnswerModel Answer { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; }
    
}