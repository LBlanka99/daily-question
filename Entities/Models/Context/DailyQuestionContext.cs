using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Context;

public class DailyQuestionContext : DbContext
{
    public DailyQuestionContext(DbContextOptions<DailyQuestionContext> contextOptions) : base(contextOptions)
    {
        
    }
    
    public DbSet<AnswerModel> AnswerModels { get; set; }
    public DbSet<CommentModel> CommentModels { get; set; }
    public DbSet<FriendsModel> FriendsModels { get; set; }
    public DbSet<QuestionModel> QuestionModels { get; set; }
    public DbSet<ReactionModel> ReactionModels { get; set; }
    public DbSet<UserModel> UserModels { get; set; }
}