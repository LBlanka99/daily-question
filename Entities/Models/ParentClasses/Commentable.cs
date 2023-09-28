using System.ComponentModel.DataAnnotations;

namespace Entities.Models.ParentClasses;

public abstract class Commentable
{
    [Key]
    public Guid Id { get; set; }
    public UserModel User { get; set; }
    [MinLength(1)]
    public string Text { get; set; }
    public DateTime Created { get; set; }
}