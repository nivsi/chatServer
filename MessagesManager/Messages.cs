using System.ComponentModel.DataAnnotations;
namespace chatServer.MessagesManager;

public class Messages : IMessage
{
    [Key]
    public string Id { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    
}