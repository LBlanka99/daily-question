using Entities.Enums;
using Entities.Models.ParentClasses;

namespace Entities.Models;

public class AnswerModel : Commentable
{
    public QuestionModel Question { get; set; }
    public Visibility Visibility { get; set; }
}