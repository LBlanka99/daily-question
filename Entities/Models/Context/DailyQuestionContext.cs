using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Context;

public class DailyQuestionContext : DbContext
{
    public DailyQuestionContext(DbContextOptions<DailyQuestionContext> contextOptions) : base(contextOptions)
    {
        
    }
    
    public DbSet<AnswerModel> AnswerModel { get; set; }
    public DbSet<CommentModel> CommentModel { get; set; }
    public DbSet<FriendsModel> FriendsModel { get; set; }
    public DbSet<QuestionModel> QuestionModel { get; set; }
    public DbSet<ReactionModel> ReactionModel { get; set; }
    public DbSet<UserModel> UserModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FriendsModel>()
            .HasKey(fr => new { fr.SenderUserId, fr.ReceiverUserId });

        modelBuilder.Entity<FriendsModel>()
            .HasOne(fr => fr.SenderUser)
            .WithMany()
            .HasForeignKey(fr => fr.SenderUserId);

        modelBuilder.Entity<FriendsModel>()
            .HasOne(fr => fr.ReceiverUser)
            .WithMany()
            .HasForeignKey(fr => fr.ReceiverUserId);

        modelBuilder.Entity<ReactionModel>()
            .HasKey(ra => new { ra.AnswerId, ra.UserId });

        modelBuilder.Entity<ReactionModel>()
            .HasOne(ra => ra.Answer)
            .WithMany(a => a.Reactions)
            .HasForeignKey(ra => ra.AnswerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReactionModel>()
            .HasOne(ra => ra.User)
            .WithMany()
            .HasForeignKey(ra => ra.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}