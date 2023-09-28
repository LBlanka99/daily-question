using Entities.Models.ParentClasses;

namespace Entities.Models;

public class CommentModel : Commentable
{
    public Commentable Parent { get; set; }
}