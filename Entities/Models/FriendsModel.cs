using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities.Models;

public class FriendsModel
{
    [Key]
    [Column(Order = 1)]
    public Guid SenderUserId { get; set; }
    
    [Key]
    [Column(Order = 2)]
    public Guid ReceiverUserId { get; set; }
    public FriendStatus Status { get; set; }
    
    [ForeignKey(nameof(SenderUserId))]
    public UserModel SenderUser { get; set; }

    [ForeignKey(nameof(ReceiverUserId))]
    public UserModel ReceiverUser { get; set; }
}